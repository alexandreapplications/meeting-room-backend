using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Places.Backend.Models.View
{
    public class PlaceGroupViewModel
    {
        /// <summary>
        /// Place Group Identification
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Subscriber controling that places
        /// </summary>
        public Guid SubscriberId { get; set; }
        /// <summary>
        /// Place code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Building name
        /// </summary>
        public string Building { get; set; }
        /// <summary>
        /// Place Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Is enabled
        /// </summary>
        public bool Enabled { get; set; }
    }
}
