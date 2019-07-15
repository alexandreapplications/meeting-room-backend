using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Places.Backend.Models.View
{
    public class PlaceViewModel
    {
        /// <summary>
        /// Place identification
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Subscriber
        /// </summary>
        public Guid SubscriberId { get; set; }
        /// <summary>
        /// Place Group Id
        /// </summary>
        public Guid PlaceGroupId { get; set; }
        /// <summary>
        /// Group
        /// </summary>
        public PlaceGroupViewModel PlaceGroup { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Location description
        /// </summary>
        public string LocationDescription { get; set; }
        /// <summary>
        /// Max users the place can accept
        /// </summary>
        public int MaxUsers { get; set; }
        /// <summary>
        /// Infrastructure of the place
        /// </summary>
        /// <example>Television, datashow</example>
        public string[] Infrastructure { get; set; }
        /// <summary>
        /// Optional infrastructure 
        /// </summary>
        /// <example>Coffe, cutelary, ...</example>
        public string[] OptionalInfrastructure { get; set; }
    }
}
