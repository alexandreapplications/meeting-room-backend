using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexandreApps.Meeting_Room.Core.Models.Places;
using AlexandreApps.Meeting_Room.Places.Backend.Models.View;
using AlexandreApps.Meeting_Room.Places.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlexandreApps.Meeting_Room.Places.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceAppService _AppService;
        public PlaceController(IPlaceAppService placeGroupApp)
        {
            this._AppService = placeGroupApp;
        }

        /// <summary>
        /// Inserts a new record
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>Inserted record</returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PlaceViewModel record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdRecord = ModelToView((await _AppService.Create(ViewToModel(record))).First());

                return Created($"api/[controller]/{ createdRecord.Id }", createdRecord);
            }
            catch (ApplicationException ex)
            {
                return new BadRequestObjectResult(ex);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        /// <summary>
        /// Inserts a new record
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>Inserted record</returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] PlaceViewModel record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedRecord = ModelToView((await _AppService.Update(ViewToModel(record))).First());

                return Accepted($"api/[controller]/{ updatedRecord.Id }", updatedRecord);
            }
            catch (ApplicationException ex)
            {
                return new BadRequestObjectResult(ex);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        private PlaceViewModel ModelToView(PlaceModel model)
        {
            return new PlaceViewModel
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name,
                SubscriberId = model.SubscriberId,
                Group = new PlaceGroupViewModel
                {
                    Id = model.Group.Id,
                    Code = model.Group.Code,
                    Building = model.Group.Building,
                    Enabled = model.Group.Enabled,
                    Name = model.Group.Name,
                    SubscriberId = model.Group.SubscriberId
                },
                Infrastructure = model.Infrastructure,
                LocationDescription = model.LocationDescription,
                MaxUsers = model.MaxUsers,
                OptionalInfrastructure = model.OptionalInfrastructure
            };
        }

        /// <summary>
        /// Deletes a record
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>Success</returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _AppService.Delete(id);

                if (result > 0)
                    return Accepted();
                return new NoContentResult();
            }
            catch (ApplicationException ex)
            {
                return new BadRequestObjectResult(ex);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        /// <summary>
        /// Gets an record by Id
        /// </summary>
        /// <param name="id">Record Id</param>
        /// <returns>Selected record</returns>
        [HttpPost("get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _AppService.Get(id);
                if (result == null)
                    return new NoContentResult();

                return new OkObjectResult(result);
            }
            catch (ApplicationException ex)
            {
                return new BadRequestObjectResult(ex);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        /// <summary>
        /// Gets an record by Id
        /// </summary>
        /// <param name="id">Record Id</param>
        /// <returns>Selected record</returns>
        [HttpGet("getbysubscription/{id}")]
        public async Task<IActionResult> GetBySubscription(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _AppService.GetListBySubscriber(id);
                if (result == null)
                    return new NoContentResult();

                return new OkObjectResult(result);
            }
            catch (ApplicationException ex)
            {
                return new BadRequestObjectResult(ex);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        private PlaceModel ViewToModel(PlaceViewModel model)
        {
            return new PlaceModel
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name,
                SubscriberId = model.SubscriberId,
                Group = new PlaceGroupModel {
                    Id = model.Group.Id,
                    Code = model.Group.Code,
                    Building =model.Group.Building,
                    Enabled = model.Group.Enabled,
                    Name = model.Group.Name,
                    SubscriberId = model.Group.SubscriberId
                },
                Infrastructure = model.Infrastructure,
                LocationDescription = model.LocationDescription,
                MaxUsers = model.MaxUsers,
                OptionalInfrastructure = model.OptionalInfrastructure
            };
        }
    }
}