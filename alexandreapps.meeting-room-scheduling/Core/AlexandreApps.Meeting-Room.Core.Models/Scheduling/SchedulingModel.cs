using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Core.Models.Scheduling
{
    /// <summary>
    /// Represents a scheduling for a place
    /// </summary>
    public class SchedulingModel
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
        /// Place Id
        /// </summary>
        public int PlaceId { get; set; }
        /// <summary>
        /// Optional infrastructure 
        /// </summary>
        /// <example>Coffe, cutelary, ...</example>
        public string[] OptionalInfrastructure { get; set; }
        /// <summary>
        /// Initial Date
        /// </summary>
        public DateTime InitialDate { get; set; }
        /// <summary>
        /// Final date
        /// </summary>
        public DateTime FinalDateDate { get; set; }
        /// <summary>
        /// Cancelation information
        /// </summary>
        public string CancelationInformation { get; set; }
        /// <summary>
        /// User that canceled the meeting
        /// </summary>
        public int CancelationUser { get; set; }
        /// <summary>
        /// Cancelation date
        /// </summary>
        public DateTime? CancelationDate { get; set; }
    }
}
