using System.Collections.Generic;
using System.Threading.Tasks;
using Cerulean.Network.Game;
using Cerulean.Network.Game.Message;
using Cerulean.Network.Game.Message.Model.Client;
using Cerulean.Network.Game.Message.Model.Server;
using Cerulean.Network.Game.Message.Model.Shared;
using Microsoft.Extensions.Logging;

namespace Cerulean.Server.Network.Handler
{
    public class ChannelHandler
    {
        #region Dependency Injection

        private readonly ILogger<ChannelHandler> logger;

        #endregion

        #region Dependency Injection

        public ChannelHandler(
            ILogger<ChannelHandler> logger)
        {
            this.logger = logger;
        }

        #endregion

        [MessageHandler(MessageOpcode.GetChannelsRequest)]
        public async Task HandleGetChannelsRequest(IGameSession session, GetChannelsRequest getChannelsRequest)
        {
            var channels = new List<ChannelInfo>();
            for (int i = 1; i < 50; i++)
            {
                channels.Add(new ChannelInfo
                {
                    ChannelId = i,
                    Population = 1
                });
            }

            await session.SendAsync(new GetChannelsResponse
            {
                Channels = channels
            });
        }

        [MessageHandler(MessageOpcode.UpdateChannelRequest)]
        public async Task HandleUpdateChannelRequest(IGameSession session, UpdateChannelRequest updateChannelRequest)
        {
            await session.SendAsync(new UpdateChannelResponse
            {
                Success = true,
                Error = UpdateChannelResponse.ErrorCode.ChannelFull
            });
        }
    }
}
