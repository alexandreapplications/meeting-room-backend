using AlexandreApps.Meeting_Room.Places.Backend.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Places.Backend.Dependences
{
    public static class DependencyBuilder
    {
        public static void Build(IServiceCollection services, IConfiguration configuration)
        {
            services = services ?? throw new ArgumentNullException(nameof(services));

            SettingsModel appSettings = new SettingsModel();

            configuration.GetSection("AppSettings").Bind(appSettings);

            services.AddSingleton<ISettingsModel, SettingsModel>(x => appSettings);

            AlexandreApps.Meeting_Room.Places.Dependences.DependencyBuilder.Build(services, configuration);
            
            switch (appSettings.DatabaseType.ToLower())
            {
                case "mongodb":
                    AlexandreApps.Meeting_Room.Places.Db.Mongo.Dependences.DependencyBuilder.Build(services, configuration);
                    break;
                default:
                    throw new ApplicationException($"Database server { appSettings.DatabaseType } does not have a driver configured");
            }
        }
    }
}
