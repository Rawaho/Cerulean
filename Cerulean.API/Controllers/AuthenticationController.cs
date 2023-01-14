using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cerulean.Network.API.Model;

namespace Cerulean.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("account/login")]
        [AllowAnonymous]
        public ActionResult AccountLogin([FromBody] AuthoriseAccountRequest request)
        {
            return new JsonResult(new AuthoriseAccountResponse
            {
                Error = AuthoriseAccountResponse.ErrorCode.None,
                AccessToken = "123456789",
                RefreshToken = "987654321"
            });
        }

        [HttpPost("character/login")]
        [Authorize("ValidAccount")]
        public ActionResult CharacterLogin([FromBody] AuthoriseCharacterRequest request)
        {
            return new JsonResult(new AuthoriseCharacterResponse
            {
                Error = AuthoriseCharacterResponse.ErrorCode.None,
                AccessToken = "123456789",
                RefreshToken = "987654321"
            });
        }
    }
}
