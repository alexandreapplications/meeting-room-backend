﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlexandreApps.Meeting_Room.Core.Models.Places
{
    /// <summary>
    /// Represents a place or room to be schedule
    /// </summary>
    public class PlaceModel
    {
        /// <summary>
        /// Place identification
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Subscriber
        /// </summary>
        public int Subscriber { get; set; }
        /// <summary>
        /// Group
        /// </summary>
        public PlaceGroupModel Group { get; set; }
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
        /// <summary>
        /// Times the place can be scheduled
        /// </summary>
        public PlaceAvailabilityModel[] PlaceAvailabilities { get; set; }
    }
}
