using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Security.Db.Mongo.Dependences
{
    /// <summary>
    /// Builds the dependency for this project
    /// </summary>
    public static class DependencyBuilder
    {
        /// <summary>
        /// Build dependence
        /// </summary>
        /// <param name="services">Services</param>
        /// <param name="configuration">Configuration</param>
        public static void Build(IServiceCollection services, IConfiguration configuration)
        {
            services = services ?? throw new ArgumentNullException(nameof(services));

            // services.AddSingleton<ISubscribeAppService, SubscribeAppService>();
            // services.AddSingleton<IUserAppService, UserAppService>();
        }
    }
}
