using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Cerulean.Game.Abstract.Entity;
using Cerulean.Network.Game;
using Cerulean.Network.Game.Message;
using Cerulean.Network.Game.Message.Model.Client;
using Cerulean.Network.Game.Message.Model.Server;
using Cerulean.Network.Game.Message.Model.Shared;
using Microsoft.Extensions.Logging;
using ProtoBuf;

namespace Cerulean.Server.Network.Handler
{
    public class SessionHandler
    {
        #region Dependency Injection

        private readonly ILogger<SessionHandler> logger;

        #endregion

        #region Dependency Injection

        public SessionHandler(
            ILogger<SessionHandler> logger)
        {
            this.logger = logger;
        }

        #endregion

        [MessageHandler(MessageOpcode.EstablishSessionRequest)]
        public async Task HandleEstablishSessionRequest(IGameSession webSocketSession, EstablishSessionRequest establishSessionRequest)
        {
            if (establishSessionRequest.Application != "Everland")
            {
                return;
            }

            var establishSessionResponse = new EstablishSessionResponse
            {
                Success = true,
                Account = new AccountInfo
                {
                    Id = 123,
                    Name = "test@test"
                },
                Character = new CharacterInfo
                {
                    Id = 1,
                    Name = "PogChamp69",
                    CreatedTimestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    Appearance = new List<CharacterAppearance>()
                    {
                        new CharacterAppearance
                        {
                            Part = CharacterAppearancePart.Eyes,
                            Value = 682
                        }
                    }
                },
                ClientTimestamp = establishSessionRequest.ClientTimestamp,
                MasterTimestamp = establishSessionRequest.ClientTimestamp
            };

            await webSocketSession.SendAsync(establishSessionResponse);




            // test
            {
                await using var streamTest = new MemoryStream();
                var test = new PlayerState
                {
                    Position = new Vector2
                    {
                        X = 1,
                        Y = 2
                    },
                    FacingDirection = FacingDirection.East,
                    DataId = 0,
                    MoveType = MoveType.Sprint,
                    GameSessionId = 6969,
                    AccountId = 123,
                    CharacterId = 1,
                    DisplayName = "PogChamp69",
                    Appearance = new List<CharacterAppearance>()
                    {
                        new CharacterAppearance
                        {
                            Part = CharacterAppearancePart.Eyes,
                            Value = 682
                        }
                    },
                    DanceIndex = 0,
                    TimeToLive = 0,
                    LastKeepAlive = 0,
                    LastMove = 0,
                    LastTeleport = 0,
                    LastChannelUpdate = 0,
                    LastApperanceUpdate = 0
                };
                Serializer.Serialize(streamTest, test);
                streamTest.Position = 0;


                await webSocketSession.SendAsync(new GameSessionOpenedEvent
                {
                    AccountId = 123,
                    CharacterId = 1,
                    MapId = 1,
                    ChannelId = 1,
                    EntityId = 1,
                    EntityState = new WrappedEntityState
                    {
                        Type = EntityType.Player,
                        Data = streamTest.ToArray()
                    }
                });
            }

            // test 2
            {
                await using var streamTest = new MemoryStream();
                var test = new PlayerState
                {
                    Position = new Vector2
                    {
                        X = 1,
                        Y = 2
                    },
                    FacingDirection = FacingDirection.East,
                    DataId = 0,
                    MoveType = MoveType.Sprint,
                    GameSessionId = 6970,
                    AccountId = 124,
                    CharacterId = 2,
                    DisplayName = "BigMeme",
                    Appearance = new List<CharacterAppearance>()
                    {
                        new CharacterAppearance
                        {
                            Part = CharacterAppearancePart.Eyes,
                            Value = 682
                        }
                    },
                    DanceIndex = 0,
                    TimeToLive = 0,
                    LastKeepAlive = 0,
                    LastMove = 0,
                    LastTeleport = 0,
                    LastChannelUpdate = 0,
                    LastApperanceUpdate = 0
                };
                Serializer.Serialize(streamTest, test);
                streamTest.Position = 0;

                await webSocketSession.SendAsync(new EntityJoinedEvent
                {
                    EntityId = 2,
                    EntityState = new WrappedEntityState
                    {
                        Type = EntityType.Player,
                        Data = streamTest.ToArray()
                    }
                });
            }

            // ---------------------------------------------


            var testInvetory = new InventorySnapshotEvent
            {
                Inventories = new List<Inventory>
                {
                    new Inventory
                    {
                        InventoryId = 1,
                        OwnerId = 1,
                        Type = Inventory.InventoryType.General,
                        Items = new List<Item>
                        {
                            new Item
                            {
                                InventoryItemId = 1,
                                ItemId = 682,
                                Quantity = 1
                            }
                        }
                    },
                    new Inventory
                    {
                        InventoryId = 2,
                        OwnerId = 1,
                        Type = Inventory.InventoryType.CharacterEquipped,
                        Items = new List<Item>
                        {
                            new Item
                            {
                                InventoryItemId = 2,
                                ItemId = 682,
                                Quantity = 1
                            }
                        }
                    }
                }
            };

            await webSocketSession.SendAsync(testInvetory);


            var testCharacter = new CharacterAppearanceUpdatedEvent
            {
                CharacterId = 1,
                Appearance = new List<CharacterAppearance>
                {
                    new CharacterAppearance
                    {
                        Part = CharacterAppearancePart.Eyes,
                        Value = 682
                    }
                }
            };

            await webSocketSession.SendAsync(testCharacter);


            // ---------------------------------------------




            return;
        }

        [MessageHandler(MessageOpcode.PingMessage)]
        public async Task HandlePingMessage(IGameSession webSocketSession, PingMessage pingMessage)
        {
            await webSocketSession.SendAsync(new PongMessage
            {
                ClientTimestamp = pingMessage.ClientTimestamp,
                ServerTimestamp = pingMessage.ServerTimestamp,
                IsMasterClock = true
            });
        }
    }
}
