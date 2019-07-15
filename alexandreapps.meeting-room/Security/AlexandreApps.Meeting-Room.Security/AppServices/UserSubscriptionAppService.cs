using AlexandreApps.Meeting_Room.Core.Models.Security;
using AlexandreApps.Meeting_Room.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.AppServices
{
    /// <summary>
    /// Treats user subscription 
    /// </summary>
    public class UserSubscriptionAppService : IUserSubscriptionAppService
    {
        /// <summary>
        /// Database service
        /// </summary>
        private readonly IUserSubscriptionDbService _DbService;
        private readonly IUserAppService _UserAppService;

        /// <summary>
        /// Creates a new UserSubscriptionAppService instances
        /// </summary>
        /// <param name="dbService">Database service</param>
        public UserSubscriptionAppService(IUserSubscriptionDbService dbService, IUserAppService userAppService)
        {
            this._DbService = dbService;
            this._UserAppService = userAppService;
        }
        /// <summary>
        /// Creates a new subscription
        /// </summary>
        /// <param name="model">Suscription data</param>
        /// <returns>Updated record</returns>
        public async Task<UserSubscriptionModel> Create(UserSubscriptionModel model)
        {
            model.Id = Guid.NewGuid();
            model.CreationDate = DateTime.Now;
            var user = await this._UserAppService.GetUser(model.UserId);
            if (user == null)
            {
                throw new ApplicationException("User doesn't exist");
            }
            model.UserCode = user.Code;
            model.UserName = user.Name;

            if (!model.Enabled && !model.DeletionDate.HasValue)
            {
                model.DeletionDate = model.CreationDate;
            }
            if (model.Enabled && model.DeletionDate.HasValue)
            {
                model.DeletionDate = null;
            }
            return await _DbService.Create(model);
        }

        /// <summary>
        /// Updates a record
        /// </summary>
        /// <param name="model">Record model</param>
        /// <returns>Record model</returns>
        public async Task<UserSubscriptionModel> Update(UserSubscriptionModel model)
        {
            var currentRecord = await _DbService.GetSingle(model.Id);
            if (currentRecord.CreationDate != model.CreationDate)
            {
                model.CreationDate = currentRecord.CreationDate;
            }
            if (model.Enabled && model.DeletionDate.HasValue)
                model.DeletionDate = null;
            if (!model.Enabled && !model.DeletionDate.HasValue)
                model.DeletionDate = DateTime.Now;
            return await _DbService.Update(model);
        }

        /// <summary>
        /// Get subscriptions by subscription id
        /// </summary>
        /// <param name="id">Subscription id</param>
        /// <returns>List of subscriptions</returns>
        public Task<IList<UserSubscriptionModel>> GetBySubscription(Guid id)
        {
            return _DbService.GetBySubscription(id);
        }

        /// <summary>
        /// Get subscriptions by user id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>List of user's subscriptions</returns>
        public Task<IList<UserSubscriptionModel>> GetByUser(Guid id)
        {
            return _DbService.GetByUser(id);
        }

        /// <summary>
        /// Gets a single record by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Record if found</returns>
        public Task<UserSubscriptionModel> GetSingle(Guid id)
        {
            return _DbService.GetSingle(id);
        }
    }
}
