using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Core.Models.Scheduling
{
    /// <summary>
    /// Represents a block of scheduling for a place
    /// </summary>
    public class PlaceBlockModel
    {
        /// <summary>
        /// Identification
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Remarks
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// Place
        /// </summary>
        public int PlaceId { get; set; }
        /// <summary>
        /// Scheduling begins
        /// </summary>
        public DateTime InitialDate { get; set; }
        /// <summary>
        /// Scheduling ends
        /// </summary>
        public DateTime FinalDateDate { get; set; }
    }
}
