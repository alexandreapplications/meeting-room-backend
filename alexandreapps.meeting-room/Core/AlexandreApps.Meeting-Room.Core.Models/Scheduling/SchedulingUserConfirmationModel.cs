using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Core.Models.Scheduling
{
    /// <summary>
    /// Informs that the application should ask for confirmation
    /// </summary>
    public class SchedulingUserConfirmationModel
    {
        /// <summary>
        /// Confirmation Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Time to ask for confirmation
        /// </summary>
        public TimeSpan TimeToAskConfirmation { get; set; }
        /// <summary>
        /// Max time the user can confirm
        /// </summary>
        public TimeSpan TimeToConfirm { get; set; }
        /// <summary>
        /// Time the user has confirmed
        /// </summary>
        public DateTime? ConfirmationTime { get; set; }
    }
}
