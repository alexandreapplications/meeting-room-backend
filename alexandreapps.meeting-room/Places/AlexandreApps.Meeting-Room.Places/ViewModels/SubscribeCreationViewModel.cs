using AlexandreApps.Meeting_Room.Core.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Places.ViewModels
{
    /// <summary>
    /// Viewmodel user informs what he need for subscription
    /// </summary>
    public class SubscribeCreationViewModel
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
        /// User code
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// User Email
        /// </summary>
        public string UserEmail { get; set; }
        /// <summary>
        /// User Telephone
        /// </summary>
        public string[] UserTelephones { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}
