using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Core.Models.Places
{
    /// <summary>
    /// Represents a group of places
    /// </summary>
    public class PlaceGroupModel
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
        /// Place Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Building name
        /// </summary>
        public string Building { get; set; }
        /// <summary>
        /// Is enabled
        /// </summary>
        public bool Enabled { get; set; }
    }
}
