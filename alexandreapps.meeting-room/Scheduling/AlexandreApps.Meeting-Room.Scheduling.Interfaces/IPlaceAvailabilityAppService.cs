﻿using AlexandreApps.Meeting_Room.Core.Models.Scheduling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Scheduling.Interfaces
{
    public interface IPlaceAvailabilityAppService
    {
        /// <summary>
        /// Creates one or mor place availability
        /// </summary>
        /// <param name="placeAvailabilities">Record</param>
        /// <returns>Created records</returns>
        Task Create(params PlaceAvailabilityModel[] placeAvailabilities);

        /// <summary>
        /// Update one or mor place availability
        /// </summary>
        /// <param name="placeAvailabilities">Record</param>
        /// <returns>Updated records</returns>
        Task<PlaceAvailabilityModel[]> Update(params PlaceAvailabilityModel[] placeAvailabilities);

        /// <summary>
        /// Delete a list of place groups
        /// </summary>
        /// <param name="models">Ids to delete</param>
        /// <returns>Places information</returns>
        Task<long> Delete(params Guid[] ids);

        /// <summary>
        /// Get a place group by key
        /// </summary>
        /// <param name="id">Places to get</param>
        /// <returns>Places information</returns>
        Task<PlaceAvailabilityModel> Get(Guid id);

        /// <summary>
        /// Get all avaliability of one place
        /// </summary>
        /// <param name="id">Availability Id</param>
        /// <returns>List of availabilities</returns>
        Task<List<PlaceAvailabilityModel>> GetByPlace(Guid id);

        /// <summary>
        /// Get a place group by key
        /// </summary>
        /// <param name="id">Subscriber id</param>
        /// <param name="date">Optional date filter</param>
        /// <returns>Places information</returns>
        Task<List<PlaceAvailabilityModel>> GetListBySubscriber(Guid id, DateTime? date);
    }
}
