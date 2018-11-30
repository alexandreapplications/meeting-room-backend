using AlexandreApps.Meeting_Room.Core.Models.Common;
using System;
using System.Collections.Generic;

namespace AlexandreApps.Meeting_Room.Core.Models.Security
{
    /// <summary>
    /// Subscriber information
    /// </summary>
    public class SubscriberModel
    {
        /// <summary>
        /// UniqueId
        /// </summary>
        public Guid Id { get; set; }
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
        public List<EmailModel> Emails { get; set; }
        /// <summary>
        /// Subscriber Telephones
        /// </summary>
        public List<PhoneModel> Telephones { get; set; }
        /// <summary>
        /// Subscriber Remarks
        /// </summary>
        public string Remarks { get; set; }
    }
}
