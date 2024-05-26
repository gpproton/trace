// Copyright (c) 2023 - 2024 drolx Labs
//
// Licensed under the Business Source License 1.1 and Trace Source Available License 1.0
// you may not use this file except in compliance with the License.
// Change License: Reciprocal Public License 1.5
//     https://mariadb.com/bsl11
//     https://trace.ng/licenses/license-1-0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Author: Godwin peter .O (me@godwin.dev)
// Created At: Thursday, 11th Apr 2024
// Modified By: Godwin peter .O
// Modified At: Thu Apr 11 2024

using Aspire.Hosting.Lifecycle;
using CliWrap;
using CliWrap.EventStream;
using Microsoft.Extensions.Logging;

namespace Trace.AppHost;

internal sealed class ExternalContainerResource(string name, string containerNameOrId) : Resource(name) {
    public string ContainerNameOrId { get; set; } = containerNameOrId;
}

internal static class ExternalContainerResourceExtensions {
    public static IResourceBuilder<ExternalContainerResource> AddExternalContainer(this IDistributedApplicationBuilder builder, string name, string containerNameOrId) {
        builder.Services.TryAddLifecycleHook<ExternalContainerResourceLifecycleHook>();

        return builder.AddResource(new ExternalContainerResource(name, containerNameOrId))
            .WithInitialState(new CustomResourceSnapshot {
                ResourceType = "External Container",
                State = "Starting",
                Properties = [new ResourcePropertySnapshot(CustomResourceKnownProperties.Source, "Custom")]
            })
            .ExcludeFromManifest();
    }
}

internal sealed class ExternalContainerResourceLifecycleHook(ResourceNotificationService notificationService, ResourceLoggerService loggerService) : IDistributedApplicationLifecycleHook, IAsyncDisposable {
    private readonly CancellationTokenSource _tokenSource = new();

    public Task BeforeStartAsync(DistributedApplicationModel appModel, CancellationToken cancellationToken = default) {
        foreach (var resource in appModel.Resources.OfType<ExternalContainerResource>()) {
            this.StartTrackingExternalContainerLogs(resource, cancellationToken);
        }

        return Task.CompletedTask;
    }

    private void StartTrackingExternalContainerLogs(ExternalContainerResource resource, CancellationToken cancellationToken) {
        var logger = loggerService.GetLogger(resource);
        _ = Task.Run(async () => {
            var cmd = Cli.Wrap("docker").WithArguments(["logs", "--follow", resource.ContainerNameOrId]);
            var cmdEvents = cmd.ListenAsync(this._tokenSource.Token);

            await foreach (var cmdEvent in cmdEvents) {
                switch (cmdEvent) {
                    case StartedCommandEvent:
                        await notificationService.PublishUpdateAsync(resource, state => state with { State = "Running" });
                        break;
                    case ExitedCommandEvent:
                        await notificationService.PublishUpdateAsync(resource, state => state with { State = "Finished" });
                        break;
                    case StandardOutputCommandEvent stdOut:
                        logger.LogInformation("External container {ResourceName} stdout: {StdOut}", resource.Name, stdOut.Text);
                        break;
                    case StandardErrorCommandEvent stdErr:
                        logger.LogInformation("External container {ResourceName} stderr: {StdErr}", resource.Name, stdErr.Text);
                        break;
                }

            }
        });
    }

    public ValueTask DisposeAsync() {
        this._tokenSource.Cancel();

        return default;
    }
}