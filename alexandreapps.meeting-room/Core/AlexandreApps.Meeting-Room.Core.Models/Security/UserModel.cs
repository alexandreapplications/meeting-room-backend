using AlexandreApps.Meeting_Room.Core.Models.Common;
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
        /// Id
        /// </summary>
        public Guid Id { get; set; }
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
        public List<EmailModel> Emails { get; set; }
        /// <summary>
        /// User Telephone
        /// </summary>
        public List<PhoneModel> Telephones { get; set; }
        /// <summary>
        /// User password history
        /// </summary>
        public List<UserPasswordHistory> PasswordHistory { get; set; }
    }
}
