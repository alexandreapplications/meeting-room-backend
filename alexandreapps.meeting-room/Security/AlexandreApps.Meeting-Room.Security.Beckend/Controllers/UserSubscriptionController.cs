using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexandreApps.Meeting_Room.Core.Models.Security;
using AlexandreApps.Meeting_Room.Security.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlexandreApps.Meeting_Room.Security.Beckend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSubscriptionController : ControllerBase
    {
        private readonly IUserSubscriptionAppService _AppService;
        public UserSubscriptionController(IUserSubscriptionAppService appService)
        {
            this._AppService = appService;
        }

        /// <summary>
        /// Inserts a new record
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>Inserted record</returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UserSubscriptionModel record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdRecord = await _AppService.Create(record);

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
        /// Updates a record
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>Inserted record</returns>
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UserSubscriptionModel record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedRecord = await _AppService.Update(record);

                return Accepted($"api/[controller]/{ record.Id }", updatedRecord);
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
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _AppService.GetByUser(id);

                if (result == null || result.Count == 0)
                    return new NoContentResult();

                var record = result.First();
                
                record.DeletionDate = DateTime.Now;

                var updatedRecord = await _AppService.Update(record);

                return Accepted();
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
                var result = await _AppService.GetSingle(id);
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
        [HttpGet("getbyuser/{id}")]
        public async Task<IActionResult> GetByUser(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _AppService.GetByUser(id);
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
                var result = await _AppService.GetBySubscription(id);
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
    }
}