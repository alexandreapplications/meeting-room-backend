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
    public class PlaceGroupController : ControllerBase
    {
        private readonly IPlaceGroupAppService _AppService;
        public PlaceGroupController(IPlaceGroupAppService placeGroupApp)
        {
            this._AppService = placeGroupApp;
        }

        /// <summary>
        /// Inserts a new record
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>Inserted record</returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PlaceGroupViewModel record)
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
        public async Task<IActionResult> Update([FromBody] PlaceGroupViewModel record)
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

        private PlaceGroupViewModel ModelToView(PlaceGroupModel model)
        {
            return new PlaceGroupViewModel
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name,
                Building = model.Building,
                Enabled = model.Enabled,
                SubscriberId = model.SubscriberId
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

        private PlaceGroupModel ViewToModel(PlaceGroupViewModel model)
        {
            return new PlaceGroupModel
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name,
                Building = model.Building,
                Enabled = model.Enabled,
                SubscriberId = model.SubscriberId
            };
        }
    }
}