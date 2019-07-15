using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.Beckend.ViewModels
{
    public class ChangeUserPasswordViewModel
    {
        /// <summary>
        /// Subscriber Code
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string PreviousPassword { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        [Required, MinLength(8)]
        public string Password { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        [Required, MinLength(8)]
        public string ConfirmPassword { get; set; }
    }
}
