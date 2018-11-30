using AlexandreApps.Meeting_Room.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.Beckend.ViewModels
{
    public class UserViewModel
    {
        /// <summary>
        /// Subscriber Code
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// User code
        /// </summary>
        [Required, MinLength(5)]
        public string UserCode { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
        [Required, MinLength(15)]
        public string UserName { get; set; }
        /// <summary>
        /// User Email
        /// </summary>
        [Required]
        public List<EmailModel> UserEmails { get; set; }
        /// <summary>
        /// User Telephone
        /// </summary>
        public List<PhoneModel> UserTelephones { get; set; }
    }
}
