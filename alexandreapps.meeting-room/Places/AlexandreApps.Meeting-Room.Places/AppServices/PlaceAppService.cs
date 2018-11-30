﻿using AlexandreApps.Meeting_Room.Core.Models.Places;
using AlexandreApps.Meeting_Room.Places.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreApps.Meeting_Room.Places.AppServices
{
    public class PlaceAppService: IPlaceAppService
    {
        /// <summary>
        /// Creates a new Place groups
        /// </summary>
        /// <param name="models">Places to create</param>
        /// <returns>Places information</returns>
        public async Task<PlaceModel[]> Create(PlaceModel[] models)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates a list of place groups
        /// </summary>
        /// <param name="models">Places to Update</param>
        /// <returns>Places information</returns>
        public async Task<PlaceModel[]> Update(PlaceModel[] models)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a list of place groups
        /// </summary>
        /// <param name="models">Ids to delete</param>
        /// <returns>Places information</returns>
        public async Task<PlaceModel[]> Delete(int[] ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a place group by key
        /// </summary>
        /// <param name="id">Places to get</param>
        /// <returns>Places information</returns>
        public async Task<PlaceModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a place group by key
        /// </summary>
        /// <param name="id">Subscriber id</param>
        /// <returns>Places information</returns>
        public async Task<PlaceModel[]> GetListBySubscriber(int id)
        {
            throw new NotImplementedException();
        }
    }
}