using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Core.Models.Scheduling
{
    /// <summary>
    /// Indicates the availability of a place
    /// </summary>
    public class PlaceAvailabilityModel
    {
        /// <summary>
        /// Place availability Id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Place Id
        /// </summary>
        public Guid PlaceId { get; set; }
        public Guid SubscriberId { get; set; }
        /// <summary>
        /// Indicates if it is a blocker that disable the scheduling for this place.
        /// </summary>
        public bool IsBlocker { get; set; }
        /// <summary>
        /// Initial Date for this record
        /// </summary>
        public DateTime? InitialDate { get; set; }
        /// <summary>
        /// Final date for this record
        /// </summary>
        public DateTime? FinalDate { get; set; }
        /// <summary>
        /// Day of week 
        /// </summary>
        public System.DayOfWeek? DayOfWeek { get; set; }
        /// <summary>
        /// Inicital time
        /// </summary>
        public int InitialTime { get; set; }
        /// <summary>
        /// Final time
        /// </summary>
        public int FinalTime { get; set; }
    }
}
