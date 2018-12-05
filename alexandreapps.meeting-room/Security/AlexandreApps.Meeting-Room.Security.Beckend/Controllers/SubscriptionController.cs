using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexandreApps.Meeting_Room.Core.Models.Common;
using AlexandreApps.Meeting_Room.Core.Models.Security;
using AlexandreApps.Meeting_Room.Core.Utils;
using AlexandreApps.Meeting_Room.Security.Beckend.ViewModels;
using AlexandreApps.Meeting_Room.Security.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AlexandreApps.Meeting_Room.Security.Beckend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscribeAppService _AppService;
        public SubscriptionController(ISubscribeAppService subscribeAppService)
        {
            this._AppService = subscribeAppService;
        }
        /// <summary>
        /// Inserts a new record
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>Inserted record</returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] SubscribeViewModel record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubscriberModel subscriberModel = new SubscriberModel
            {
                Code = record.Code,
                Name = record.Name,
                Emails = record.Emails,
                Remarks = record.Remarks
            };

            try
            {
                var createdRecord = (await this._AppService.Create(subscriberModel));

                return Created($"api/[controller]/{ createdRecord.Id }", createdRecord);
            }
            catch (ApplicationException ex)
            {
                return new BadRequestObjectResult(ex);
            }

        }

        [HttpGet("getbycode/{id}")]
        public async Task<IActionResult> GetByCode(string id)
        {
            try
            {
                var record = (await _AppService.GetByCode(id));

                return new OkObjectResult(record);
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