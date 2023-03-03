using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies;
using Hangfire.Mongo.Migration.Strategies.Backup;
using InternApp.API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace InternApp.API
{
    public static class HangfireDb
    {
        
        public static void ConfigureServices(this IServiceCollection services, IConfiguration config)
        {
            IMongoClient mongoClient = new MongoClient(config.GetSection("WeatherDatabase")["ConnectionString"]);

            //Add Hangfire services.Hangfire.AspNetCore nuget required
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMongoStorage(mongoClient, config.GetSection("WeatherDatabase")["DatabaseName"], new MongoStorageOptions
                {
                    MigrationOptions = new MongoMigrationOptions
                    {
                        MigrationStrategy = new MigrateMongoMigrationStrategy(),
                        BackupStrategy = new CollectionMongoBackupStrategy()
                    },
                    Prefix = "hangfire.mongo",
                    CheckConnection = true
                })
            );
            // Add the processing server as IHostedService
            var options = new BackgroundJobServerOptions
            {
                Queues = new[] { "alpha", "beta", "default" }
            };
            services.AddHangfireServer(serverOptions =>
            {
                serverOptions.ServerName = "HangfireDb";
            });

            // Add framework services.
        }

       
    }
}
