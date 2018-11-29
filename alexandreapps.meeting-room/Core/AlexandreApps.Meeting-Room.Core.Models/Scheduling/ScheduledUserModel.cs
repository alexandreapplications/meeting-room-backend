using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Core.Models.Scheduling
{
    /// <summary>
    /// Represents a scheduled user
    /// </summary>
    public class ScheduledUserModel
    {
        /// <summary>
        /// User Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User Email
        /// </summary>
        public string[] Emails { get; set; }
        /// <summary>
        /// User Telephone
        /// </summary>
        public string[] Telephones { get; set; }
        /// <summary>
        /// Inform that the user should receive an email asking for confirmation
        /// </summary>
        public SchedulingUserConfirmationModel ScheduleUserConfirmation { get; set; }
        /// <summary>
        /// Is a external user
        /// </summary>
        public bool External { get; set; }
    }
}
