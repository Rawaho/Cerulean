using System.Net.WebSockets;

namespace Cerulean.Network.Game
{
    public interface IGameSession
    {
        void Accept(WebSocket newWebSocket);
        void Shutdown();

        Task Receive();

        Task SendAsync(IEnumerable<object> model);
        Task SendAsync(object model);
    }
}
