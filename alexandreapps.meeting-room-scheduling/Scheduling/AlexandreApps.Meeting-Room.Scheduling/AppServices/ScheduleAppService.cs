using AlexandreApps.Meeting_Room.Core.Models.Scheduling;
using AlexandreApps.Meeting_Room.Scheduling.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Scheduling.AppServices
{
    public class ScheduleAppService: IScheduleAppService
    {
        /// <summary>
        /// Schedules a meeting
        /// </summary>
        /// <param name="models">Schedules to add</param>
        /// <returns>Updated information</returns>
        public async Task<SchedulingModel[]> Create (SchedulingModel models)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Updates Schedules a meeting
        /// </summary>
        /// <param name="models">Schedules to update</param>
        /// <returns>Updated information</returns>
        public async Task<SchedulingModel[]> Update(SchedulingModel models)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get meetings for a place in periodo of time 
        /// </summary>
        /// <param name="placeId">Schedules to update</param>
        /// <param name="initialDate">Schedules to update</param>
        /// <param name="finalDate">Schedules to update</param>
        /// <returns>List of meetings for the place</returns>
        public async Task<SchedulingModel[]> GetByPlaceDate(int placeId, DateTime initialDate, DateTime finalDate)
        {
            throw new NotImplementedException();
        }
    }
}
