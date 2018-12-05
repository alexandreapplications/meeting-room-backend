using AlexandreApps.Meeting_Room.Places.Db.Mongo.DbServices;
using AlexandreApps.Meeting_Room.Places.Db.Mongo.Settings;
using AlexandreApps.Meeting_Room.Places.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Places.Db.Mongo.Dependences
{
    public static class DependencyBuilder
    {/// <summary>
     /// Build dependence
     /// </summary>
     /// <param name="services">Services</param>
     /// <param name="configuration">Configuration</param>
        public static void Build(IServiceCollection services, IConfiguration configuration)
        {
            services = services ?? throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IPlaceDbService, PlaceDbService>();
            services.AddSingleton<IPlaceGroupDbService, PlaceGroupDbService>();
            // PlaceDbService: IPlaceDbService
            SettingsModel appSettings = new SettingsModel();

            configuration.GetSection("AppSettings").GetSection("MongoDB").Bind(appSettings);

            services.AddSingleton<ISettingsModel, SettingsModel>(x => appSettings);
        }
    }
}
