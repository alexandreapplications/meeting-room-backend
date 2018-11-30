using AlexandreApps.Meeting_Room.Core.Models.Security;
using AlexandreApps.Meeting_Room.Core.Utils;
using AlexandreApps.Meeting_Room.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.AppServices
{
    /// <summary>
    /// Treats subscribition.
    /// </summary>
    public class SubscribeAppService: ISubscribeAppService
    {
        private readonly ISubscribeDbService _SubscribeDb;

        public SubscribeAppService(ISubscribeDbService subscribeDb)
        {
            _SubscribeDb = subscribeDb;
        }
        /// <summary>
        /// Allow the user to subscribe
        /// </summary>
        /// <param name="subscriber">Subscriber</param>
        /// <param name="user">User</param>
        /// <returns>If was possible or error</returns>
        public async Task<SubscriberModel> Create(SubscriberModel subscriber)
        {
            subscriber.Id = Guid.NewGuid();
            subscriber.Emails.ForEach(x => x.Id = Guid.NewGuid());
            return await _SubscribeDb.Create(subscriber);
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