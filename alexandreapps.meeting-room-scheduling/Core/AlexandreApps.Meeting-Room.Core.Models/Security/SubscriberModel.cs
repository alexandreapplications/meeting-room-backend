using System;

namespace AlexandreApps.Meeting_Room.Core.Models.Security
{
    /// <summary>
    /// Subscriber information
    /// </summary>
    public class SubscriberModel
    {
        /// <summary>
        /// Subscriber Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Subscriber Code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Subscriber Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Subscriber Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Subscriber Remarks
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// Subscriber Administrator
        /// </summary>
        public UserModel[] Administrators { get; set; }
    }
}
