using AlexandreApps.Meeting_Room.Core.Models.Scheduling;
using AlexandreApps.Meeting_Room.Scheduling.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Scheduling.AppServices
{
    /// <summary>
    /// Manages the place availability on application
    /// </summary>
    public class PlaceAvailabilityAppService: IPlaceAvailabilityAppService
    {
        /// <summary>
        /// Creates one or mor place availability
        /// </summary>
        /// <param name="placeAvailabilities">Record</param>
        /// <returns>Created records</returns>
        public async Task<PlaceAvailabilityModel[]> Create(PlaceAvailabilityModel[] placeAvailabilities)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update one or mor place availability
        /// </summary>
        /// <param name="placeAvailabilities">Record</param>
        /// <returns>Updated records</returns>
        public async Task<PlaceAvailabilityModel[]> Update(PlaceAvailabilityModel[] placeAvailabilities)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// Get all avaliability of one place
        /// </summary>
        /// <param name="id">Availability Id</param>
        /// <returns>List of availabilities</returns>
        public async Task<PlaceAvailabilityModel[]> GetByPlace(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all availability by date
        /// </summary>
        /// <param name="date">Avaliability date</param>
        /// <returns>List</returns>
        public async Task<PlaceAvailabilityModel[]> GetListByDate(DateTime date)
        {
            throw new NotImplementedException();

        }
    }
}
