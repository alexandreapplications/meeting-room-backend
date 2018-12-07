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
        [HttpPut("update/{id}")]
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

        /// <summary>
        /// Deletes a record
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>Success</returns>
        [HttpDelete("delete/{id}")]
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
        [HttpGet("get/{id}")]
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
                PlaceGroup = new PlaceGroupModel
                {
                    Id = model.PlaceGroupId
                },
                Infrastructure = model.Infrastructure,
                LocationDescription = model.LocationDescription,
                MaxUsers = model.MaxUsers,
                OptionalInfrastructure = model.OptionalInfrastructure
            };
        }


        private PlaceViewModel ModelToView(PlaceModel model)
        {
            return new PlaceViewModel
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name,
                SubscriberId = model.SubscriberId,
                PlaceGroupId = model.PlaceGroup.Id,
                Group = new PlaceGroupViewModel
                {
                    Id = model.PlaceGroup.Id,
                    Code = model.PlaceGroup.Code,
                    Name = model.PlaceGroup.Name,
                    Enabled = model.PlaceGroup.Enabled,
                    SubscriberId = model.PlaceGroup.SubscriberId,
                    Building = model.PlaceGroup.Building
                },
                Infrastructure = model.Infrastructure,
                LocationDescription = model.LocationDescription,
                MaxUsers = model.MaxUsers,
                OptionalInfrastructure = model.OptionalInfrastructure
            };
        }

    }
}