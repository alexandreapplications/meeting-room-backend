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
        private readonly ISubscribeAppService appService;
        public SubscriptionController(ISubscribeAppService subscribeAppService)
        {
            this.appService = subscribeAppService;
        }
        /// <summary>
        /// Inserts a new record
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>Inserted record</returns>
        [HttpPut("Create")]
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
                Administrators = new List<UserModel>(),
                Remarks = record.Remarks
            };

            try
            {
                var createdRecord = (await this.appService.Create(subscriberModel));

                return Created($"api/[controller]/{ createdRecord.Id }", createdRecord);
            }
            catch (ApplicationException ex)
            {
                return new BadRequestObjectResult(ex);
            }

        }
    }
}