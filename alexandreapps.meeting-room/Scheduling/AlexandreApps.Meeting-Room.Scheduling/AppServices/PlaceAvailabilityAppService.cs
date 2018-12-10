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
    public class PlaceAvailabilityAppService : IPlaceAvailabilityAppService
    {
        private readonly IPlaceAvailabilityDbService _dbService;

        public PlaceAvailabilityAppService(IPlaceAvailabilityDbService dbService)
        {
            this._dbService = dbService;
        }

        public Task Create(params PlaceAvailabilityModel[] placeAvailabilities)
        {
            return _dbService.Create(placeAvailabilities);
        }

        public Task<PlaceAvailabilityModel[]> Update(params PlaceAvailabilityModel[] placeAvailabilities)
        {
            return _dbService.Update(placeAvailabilities);
        }

        public Task<long> Delete(params Guid[] ids)
        {
            return _dbService.Delete(ids);
        }

        public Task<PlaceAvailabilityModel> Get(Guid id)
        {
            return _dbService.Get(id);
        }

        public Task<List<PlaceAvailabilityModel>> GetByPlace(Guid id)
        {
            return _dbService.GetByPlace(id);
        }

        public Task<List<PlaceAvailabilityModel>> GetListBySubscriber(Guid id, DateTime? date)
        {
            return _dbService.GetListBySubscriber(id, date);
        }

    }
}
