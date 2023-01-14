using System;
using System.Collections.Generic;
using Cerulean.Game.Abstract.Entity;
using Cerulean.Network.API.Model;
using Cerulean.Network.API.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cerulean.API.Controllers
{
    [ApiController]
    [Route("character")]
    [Authorize("ValidAccount")]
    public class CharacterController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetCharacters()
        {
            return new JsonResult(new GetAccountCharactersResponse
            {
                Error = GetAccountCharactersResponse.ErrorCode.None,
                Characters = new List<Character>
                {
                    new Character
                    {
                        AccountId = 123,
                        CharacterId = 1,
                        Name = "PogChamp",
                        CreatedAt = DateTimeOffset.Now
                    }
                },
                Appearances = new Dictionary<long, Dictionary<CharacterAppearancePart, long>>
                {
                    {
                        1, new Dictionary<CharacterAppearancePart, long>
                        {

                        }
                    }
                }
            });
        }

        [HttpPost]
        public ActionResult CreateCharacter([FromBody] CreateCharacterRequest request)
        {
            return new JsonResult(new CreateCharacterResponse
            {
                Error = CreateCharacterResponse.ErrorCode.None,
                Character = new Character
                {
                    AccountId = 123,
                    CharacterId = 1,
                    Name = "PogChamp",
                    CreatedAt = DateTimeOffset.Now
                }
            });
        }
    }
}
