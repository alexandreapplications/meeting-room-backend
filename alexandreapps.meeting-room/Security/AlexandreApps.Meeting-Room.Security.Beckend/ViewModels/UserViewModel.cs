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
        public string Code { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
        [Required, MinLength(15)]
        public string Name { get; set; }
        /// <summary>
        /// User Email
        /// </summary>
        [Required]
        public List<EmailModel> Emails { get; set; }
        /// <summary>
        /// User Telephone
        /// </summary>
        public List<PhoneModel> Telephones { get; set; }
    }
}
