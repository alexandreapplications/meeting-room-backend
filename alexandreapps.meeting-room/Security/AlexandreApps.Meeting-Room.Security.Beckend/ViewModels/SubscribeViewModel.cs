using AlexandreApps.Meeting_Room.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.Beckend.ViewModels
{
    /// <summary>
    /// Viewmodel user informs what he need for subscription
    /// </summary>
    public class SubscribeViewModel
    {
        /// <summary>
        /// Subscriber Code
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Subscriber Code
        /// </summary>
        [Required, MinLength(5)]
        public string Code { get; set; }
        /// <summary>
        /// Subscriber Name
        /// </summary>
        [Required, MinLength(15)]
        public string Name { get; set; }
        /// <summary>
        /// Subscriber Email
        /// </summary>
        public List<EmailModel> Emails { get; set; }
        /// <summary>
        /// Subscriber Remarks
        /// </summary>
        [MinLength(5)]
        public string Remarks { get; set; }
    }
}
