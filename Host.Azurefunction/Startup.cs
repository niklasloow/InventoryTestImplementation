using System.IO;
using Common;
using Host.AzureFunction;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Host.AzureFunction
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
#if DEBUG
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: false)
#endif
                .AddEnvironmentVariables()
                .Build();
            builder.Services.AddCommonInjection(config);

        }
    }
}
