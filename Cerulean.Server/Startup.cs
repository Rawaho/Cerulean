using Cerulean.Network.Game;
using Cerulean.Network.Game.Message;
using Cerulean.Network.Game.Packet;
using Cerulean.Server.Middleware;
using Cerulean.Server.Network;
using Cerulean.Server.Network.Handler;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cerulean.Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            // network
            serviceCollection.AddFactory<IGameSession, GameSession>();
            serviceCollection.AddFactory<IWebSocketPacket, WebSocketPacket>();
            serviceCollection.AddFactory<IPacketReader, PacketReader>();
            serviceCollection.AddFactory<IPacketWriter, PacketWriter>();
            serviceCollection.AddFactory<IMessageHandlerDelegate, MessageHandlerDelegate>();

            serviceCollection.AddSingleton<ISessionService, SessionService>();
            serviceCollection.AddSingleton<IMessageService, MessageService>();




            serviceCollection.AddSingleton<SessionHandler>();
            serviceCollection.AddSingleton<ChannelHandler>();
        }

        public void Configure(
            IApplicationBuilder applicationBuilder,
            IMessageService messageService)
        {
            applicationBuilder.UseWebSockets();
            applicationBuilder.UseWebSocketMiddleware();

            messageService.Initialise();
        }
    }
}
