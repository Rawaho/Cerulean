using System;
using Cerulean.Network.API.Model;
using Cerulean.Network.API.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Cerulean.API.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAccount()
        {
            return new JsonResult(new GetAccountResponse
            {
                Error = GetAccountResponse.ErrorCode.None,
                Account = new Account
                {
                    AccountId = 123,
                    Email = "test@test",
                    CreatedAt = DateTimeOffset.Now,
                    IsAdmin = true
                }
            });
        }
    }
}
