﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Scheduling.Backend.Dependences
{
    public static class DependencyBuilder
    {
        public static void Build(IServiceCollection services, IConfiguration configuration)
        {
            //services = services ?? throw new ArgumentNullException(nameof(services));
        }
    }
}
