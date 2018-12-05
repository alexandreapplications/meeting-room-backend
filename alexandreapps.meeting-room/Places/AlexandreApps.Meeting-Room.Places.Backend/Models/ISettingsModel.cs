using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Places.Backend.Models
{
    public interface ISettingsModel
    {
        string DatabaseType { get; set; }
    }
}
