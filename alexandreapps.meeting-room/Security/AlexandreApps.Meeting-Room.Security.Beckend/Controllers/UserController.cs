using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlexandreApps.Meeting_Room.Core.Models.Security;
using AlexandreApps.Meeting_Room.Security.Beckend.ViewModels;
using AlexandreApps.Meeting_Room.Security.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlexandreApps.Meeting_Room.Security.Beckend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _AppService;
        public UserController(IUserAppService userAppService)
        {
            this._AppService = userAppService;
        }
        /// <summary>
        /// Inserts a new record
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>Inserted record</returns>
        [HttpPut("Create")]
        public async Task<IActionResult> Create([FromBody] UserViewModel record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserModel userModel = new UserModel
            {
                Code = record.UserCode,
                Name = record.UserName,
                Emails = record.UserEmails,
                Telephones = record.UserTelephones
            };

            try
            {
                var createdRecord = (await _AppService.Create(userModel)).First();

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
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordViewModel record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (record.Password != record.ConfirmPassword)
            {
                ModelState.AddModelError("PasswordConfirmation", "The password differs from its confirmation");
            }

            try
            {
                Dictionary<string, string> remarks = new Dictionary<string, string>();
                
                if (await _AppService.ChangePassword(record.Id, record.PreviousPassword, record.Password, remarks))
                {
                    return Accepted($"api/[controller]/{ record.Id }");
                }
                foreach(var item in remarks)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
                return BadRequest(ModelState);
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

        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            throw new NotImplementedException();
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //try
            //{
            //    Dictionary<string, string> remarks;

            //    string autenticationTicket;

            //    if (await _AppService.LogIn(login.UserId, login.Password, out remarks, out autenticationTicket))
            //    {
            //        return Accepted($"api/[controller]/{ record.autenticationTicket }");
            //    }
            //    foreach (var item in remarks)
            //    {
            //        ModelState.AddModelError(item.Key, item.Value);
            //    }
            //    return BadRequest(ModelState);
            //}
            //catch (ApplicationException ex)
            //{
            //    return new BadRequestObjectResult(ex);
            //}
            //catch (Exception ex)
            //{
            //    return new BadRequestObjectResult(ex);
            //}
        }
    }
}