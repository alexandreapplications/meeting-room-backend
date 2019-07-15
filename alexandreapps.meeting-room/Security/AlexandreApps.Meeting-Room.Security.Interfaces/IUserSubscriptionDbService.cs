using AlexandreApps.Meeting_Room.Core.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.Interfaces
{
    public interface IUserSubscriptionDbService
    {
        /// <summary>
        /// Creates a new subscription
        /// </summary>
        /// <param name="model">Suscription data</param>
        /// <returns>Updated record</returns>
        Task<UserSubscriptionModel> Create(UserSubscriptionModel model);

        /// <summary>
        /// Updates a record
        /// </summary>
        /// <param name="model">Record model</param>
        /// <returns>Updated model</returns>
        Task<UserSubscriptionModel> Update(UserSubscriptionModel model);

        /// <summary>
        /// Gets a single record by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Record if found</returns>
        Task<UserSubscriptionModel> GetSingle(Guid id);

        /// <summary>
        /// Get subscriptions by user id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>List of user's subscriptions</returns>
        Task<IList<UserSubscriptionModel>> GetByUser(Guid id);

        /// <summary>
        /// Get subscriptions by subscription id
        /// </summary>
        /// <param name="id">Subscription id</param>
        /// <returns>List of subscriptions</returns>
        Task<IList<UserSubscriptionModel>> GetBySubscription(Guid id);
        /// <summary>
        /// Propagates the user information updates
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="code">User Code</param>
        /// <param name="name">User Name</param>
        /// <returns>Task to be run</returns>
        long UpdateUserInformation(Guid userId, string code, string name);
    }
}
