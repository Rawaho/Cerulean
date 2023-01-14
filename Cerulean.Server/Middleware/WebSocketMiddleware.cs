using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Cerulean.Network.Game;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Cerulean.Server.Middleware
{
    public class WebSocketMiddleware
    {
        #region Dependency Injection

        private readonly RequestDelegate next;
        private readonly Func<IGameSession> sessionFactory;

        #endregion

        #region Dependency Injection

        public WebSocketMiddleware(
            RequestDelegate next,
            Func<IGameSession> sessionFactory)
        {
            this.next = next;
            this.sessionFactory = sessionFactory;
        }

        #endregion

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.WebSockets.IsWebSocketRequest)
            {
                WebSocket webSocket = await httpContext.WebSockets.AcceptWebSocketAsync();

                IGameSession session = sessionFactory();
                session.Accept(webSocket);
                await session.Receive();
            }

            await next(httpContext);
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseWebSocketMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WebSocketMiddleware>();
        }
    }
}
