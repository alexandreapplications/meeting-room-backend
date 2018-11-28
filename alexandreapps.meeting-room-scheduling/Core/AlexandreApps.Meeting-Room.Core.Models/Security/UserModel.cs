using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Core.Models.Security
{
    /// <summary>
    /// Application User
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// User Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// User code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// User Telephone
        /// </summary>
        public string[] Telephones { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public byte[] Password { get; set; }
    }
}
