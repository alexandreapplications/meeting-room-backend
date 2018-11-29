using AlexandreApps.Meeting_Room.Core.Models.Security;
using AlexandreApps.Meeting_Room.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.AppServices
{
    public class SubscribeAppService: ISubscribeAppService
    {
        /// <summary>
        /// Allow the user to subscribe
        /// </summary>
        /// <param name="model">Subscribition Information</param>
        /// <returns>If was possible or error</returns>
        public async Task<SubscriberModel> Create(SubscriberModel subscriber, UserModel user)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Updates the subscriber info
        /// </summary>
        /// <param name="model">Subscriber info</param>
        /// <returns>New Information</returns>
        /// <remarks>To delete, disable the user</remarks>
        public async Task<SubscriberModel> Update(SubscriberModel model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get subscriber information
        /// </summary>
        /// <param name="id">Subscriber id</param>
        /// <returns>Subscriber information</returns>
        public async Task<SubscriberModel> Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}