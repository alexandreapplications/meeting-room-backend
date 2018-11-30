using AlexandreApps.Meeting_Room.Core.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.Interfaces
{
    /// <summary>
    /// Interface for subscribition
    /// </summary>
    public interface ISubscribeDbService
    {
        /// <summary>
        /// Creates a new subscription
        /// </summary>
        /// <param name="model">Suscription data</param>
        /// <returns>Updated record</returns>
        Task<SubscriberModel> Create(SubscriberModel model);
    }
}
