// Copyright (c) 2023 - 2024 drolx Solutions
//
// Licensed under the Business Source License 1.1 and Trace Source Available License 1.0
// you may not use this file except in compliance with the License.
// Change License: Reciprocal Public License 1.5
//     https://mariadb.com/bsl11
//     https://opensource.org/license/rpl-1-5
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Author: Godwin peter .O (me@godwin.dev)
// Created At: Sunday, 31st Dec 2023
// Modified By: Godwin peter .O
// Modified At: Sat Jan 06 2024

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using Trace.Common.Queueing.Implementation;
using Trace.Common.Queueing.Interfaces;

namespace Trace.Common.Queueing.Extensions;

public static class QueueingStartupExtensions {
    public static void AddQueueing(this IServiceCollection services) {
        var scope = services.BuildServiceProvider();
        var config = scope.GetRequiredService<IConfiguration>();
        // services.AddSingleton<IAsyncConnectionFactory>(provider => provider.GetRequiredService<IConnectionFactory>() )

        // services.AddSingleton<IAsyncConnectionFactory>(provider => {
        //     var factory = new ConnectionFactory {
        //         Uri = new Uri(config.GetConnectionString("messaging") ?? "localhost"),
        //         DispatchConsumersAsync = true,
        //         AutomaticRecoveryEnabled = true,
        //         ConsumerDispatchConcurrency = 5
        //     };

        //     return factory;
        // });

        // services.AddSingleton<IConnectionProvider, ConnectionProvider>();
        services.AddScoped<IChannelProvider, ChannelProvider>();
        services.AddScoped(typeof(IQueueChannelProvider<>), typeof(QueueChannelProvider<>));
        services.AddScoped(typeof(IQueueProducer<>), typeof(QueueProducer<>));
    }

    public static void AddQueueMessageConsumer<TMessageConsumer, TQueueMessage>(this IServiceCollection services) where TMessageConsumer : IQueueConsumer<TQueueMessage> where TQueueMessage : class, IQueueMessage {
        services.AddScoped(typeof(TMessageConsumer));
        services.AddScoped<IQueueConsumerHandler<TMessageConsumer, TQueueMessage>, QueueConsumerHandler<TMessageConsumer, TQueueMessage>>();
        services.AddHostedService<QueueConsumerRegistratorService<TMessageConsumer, TQueueMessage>>();
    }
}