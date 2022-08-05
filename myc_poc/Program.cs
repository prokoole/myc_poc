using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace myc_poc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
                webBuilder.ConfigureAppConfiguration(config =>
                {
                    var settings = config.Build();
                    config.AddAzureAppConfiguration(options =>
                        options.Connect(settings[Consts.AzureConfiguration.AzureConfigurationConnectionString])
                            .UseFeatureFlags(featureFlagOptions =>
                                {
                                    featureFlagOptions.CacheExpirationInterval = TimeSpan.FromSeconds(Consts.AzureConfiguration.AzureConfigurationCacheExpirationIntervalInSeconds);
                                }));
                }).UseStartup<Startup>());
    }
}
