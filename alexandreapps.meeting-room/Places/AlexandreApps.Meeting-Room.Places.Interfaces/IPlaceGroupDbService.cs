﻿using AlexandreApps.Meeting_Room.Core.Models.Places;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Places.Interfaces
{
    /// <summary>
    /// Expose group places services
    /// </summary>
    public interface IPlaceGroupDbService
    {
        /// <summary>
        /// Creates a new Place groups
        /// </summary>
        /// <param name="models">Places to create</param>
        /// <returns>Task</returns>
        Task Create(PlaceGroupModel[] models);


        /// <summary>
        /// Updates a list of place groups
        /// </summary>
        /// <param name="models">Places to Update</param>
        /// <returns>Places information</returns>
        Task<PlaceGroupModel[]> Update(PlaceGroupModel[] models);

        /// <summary>
        /// Delete a list of place groups
        /// </summary>
        /// <param name="models">Ids to delete</param>
        /// <returns>Places information</returns>
        Task<long> Delete(Guid[] ids);

        /// <summary>
        /// Get a place group by key
        /// </summary>
        /// <param name="id">Places to get</param>
        /// <returns>Places information</returns>
        Task<PlaceGroupModel> Get(Guid id);

        /// <summary>
        /// Get a place group by key
        /// </summary>
        /// <param name="id">Subscriber id</param>
        /// <returns>Places information</returns>
        Task<List<PlaceGroupModel>> GetListBySubscriber(Guid id);
    }
}
