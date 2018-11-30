using AlexandreApps.Meeting_Room.Core.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.Interfaces
{
    public interface ISubscribeAppService
    {
        /// <summary>
        /// Allow the user to subscribe
        /// </summary>
        /// <param name="model">Subscribition Information</param>
        /// <returns>If was possible or error</returns>
        Task<SubscriberModel> Create(SubscriberModel model);
        /// <summary>
        /// Updates the subscriber info
        /// </summary>
        /// <param name="model">Subscriber info</param>
        /// <returns>New Information</returns>
        /// <remarks>To delete, disable the user</remarks>
        Task<SubscriberModel> Update(SubscriberModel model);
        /// <summary>
        /// Get subscriber information
        /// </summary>
        /// <param name="id">Subscriber id</param>
        /// <returns>Subscriber information</returns>
        Task<SubscriberModel> Get(string id);
    }
}
