using AlexandreApps.Meeting_Room.Core.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Security.Interfaces
{
    /// <summary>
    /// User database service
    /// </summary>
    public interface IUserDbService
    {
        /// <summary>
        /// Creates a new subscription
        /// </summary>
        /// <param name="model">Suscription data</param>
        /// <returns>Updated record</returns>
        Task<UserModel> Create(UserModel model);
        /// <summary>
        /// Gets a record
        /// </summary>
        /// <param name="uniqueId">Unique Id</param>
        /// <returns>Record or default</returns>
        Task<UserModel> GetSingle(Guid uniqueId);
        /// <summary>
        /// Updates a record
        /// </summary>
        /// <param name="model">Record model</param>
        /// <returns>If operation has succeded</returns>
        Task<bool> Update(UserModel model);
    }
}
