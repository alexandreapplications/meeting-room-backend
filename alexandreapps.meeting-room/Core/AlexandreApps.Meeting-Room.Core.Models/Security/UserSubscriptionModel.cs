using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Core.Models.Security
{
    public class UserSubscriptionModel
    {
        public Guid Id { get; set; }
        public Guid SubscriptionId { get; set; }
        public Guid UserId { get; set; }
        public bool IsOwner { get; set; }
        public IList<string> Roles { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}
