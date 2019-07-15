using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Core.Models.Security
{
    public class UserPasswordHistory
    {
        /// <summary>
        /// UniqueId
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Password date
        /// </summary>
        public DateTime InitialDate { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public byte[] Password { get; set; }
    }
}
