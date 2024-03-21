// Copyright 2022 - 2023 Godwin peter .O (me@godwin.dev)
// 
// Licensed under the Reciprocal Public License (RPL-1.5) and Trace Source Available License 1.0;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Trace.Common.Domain.Context;

public class OperationContextFactory : IDesignTimeDbContextFactory<OperationContext>
{
    public OperationContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OperationContext>();
        var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
        var connectionString = config.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString, b => b
                 .MigrationsAssembly(typeof(OperationContext).Assembly.FullName)
                 .UseNetTopologySuite()
                 .EnableRetryOnFailure())
                .UseSnakeCaseNamingConvention();

        return new OperationContext(optionsBuilder.Options);
    }
}