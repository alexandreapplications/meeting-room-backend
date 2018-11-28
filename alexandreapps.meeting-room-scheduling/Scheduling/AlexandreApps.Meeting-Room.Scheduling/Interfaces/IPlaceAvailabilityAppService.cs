using AlexandreApps.Meeting_Room.Core.Models.Scheduling;
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
        Task<PlaceAvailabilityModel[]> Create(PlaceAvailabilityModel[] placeAvailabilities);

        /// <summary>
        /// Update one or mor place availability
        /// </summary>
        /// <param name="placeAvailabilities">Record</param>
        /// <returns>Updated records</returns>
        Task<PlaceAvailabilityModel[]> Update(PlaceAvailabilityModel[] placeAvailabilities);

        /// <summary>
        /// Get all avaliability of one place
        /// </summary>
        /// <param name="id">Availability Id</param>
        /// <returns>List of availabilities</returns>
        Task<PlaceAvailabilityModel[]> GetByPlace(int id);

        /// <summary>
        /// Get all availability by date
        /// </summary>
        /// <param name="date">Avaliability date</param>
        /// <returns>List</returns>
        Task<PlaceAvailabilityModel[]> GetListByDate(DateTime date);
    }
}
