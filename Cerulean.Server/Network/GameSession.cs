using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Cerulean.Network.Game;
using Cerulean.Network.Game.Message;
using Cerulean.Network.Game.Packet;
using Microsoft.Extensions.Logging;

namespace Cerulean.Server.Network
{
    public class GameSession : IGameSession
    {
        #region Dependency Injection

        private readonly ILogger<GameSession> logger;

        private readonly Func<IWebSocketPacket> webSocketPacketFactory;
        private readonly Func<IPacketReader> packetReaderFactory;
        private readonly Func<IPacketWriter> packetWriterFactory;

        private readonly IMessageService messageService;

        #endregion

        /// <summary>
        /// Unique identifier for session. 
        /// </summary>
        public Guid Identifier { get; } = Guid.NewGuid();

        private WebSocket webSocket;
        private IWebSocketPacket webSocketPacket;
        private readonly Memory<byte> buffer = new byte[4096];

        private readonly CancellationTokenSource cancellationSource = new CancellationTokenSource();

        #region Dependency Injection

        public GameSession(
            ILogger<GameSession> logger,
            Func<IWebSocketPacket> webSocketPacketFactory,
            Func<IPacketReader> packetReaderFactory,
            Func<IPacketWriter> packetWriterFactory,
            IMessageService messageService)
        {
            this.logger = logger;

            this.webSocketPacketFactory = webSocketPacketFactory;
            this.packetReaderFactory = packetReaderFactory;
            this.packetWriterFactory = packetWriterFactory;

            this.messageService = messageService;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void Accept(WebSocket newWebSocket)
        {
            webSocket = newWebSocket;
            logger.LogTrace($"Accepted new connection {Identifier}.");
        }

        /// <summary>
        /// 
        /// </summary>
        public void Shutdown()
        {
            cancellationSource.Cancel();
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task Receive()
        {
            try
            {
                while (!cancellationSource.IsCancellationRequested)
                {
                    ValueWebSocketReceiveResult result = await webSocket.ReceiveAsync(buffer, cancellationSource.Token);
                    switch (result.MessageType)
                    {
                        case WebSocketMessageType.Binary:
                            {
                                webSocketPacket ??= webSocketPacketFactory();
                                await webSocketPacket.OnDataAsync(buffer[..result.Count], result.EndOfMessage, cancellationSource.Token);

                                if (webSocketPacket.IsComplete)
                                {
                                    OnData();
                                    webSocketPacket = null;
                                }

                                break;
                            }
                        case WebSocketMessageType.Close:
                            {
                                break;
                            }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task SendAsync(object model)
        {
            try
            {
                MessageOpcode? opcode = messageService.GetMessageOpcode(model.GetType());
                if (opcode == null)
                {
                    return;
                }

                IPacketWriter packetWriter = packetWriterFactory();
                packetWriter.Add(opcode.Value, model);
                var lol = packetWriter.Build();



                await webSocket.SendAsync(lol, WebSocketMessageType.Binary, true, cancellationSource.Token);

                logger.LogTrace($"Send message {opcode.Value}.");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task SendAsync(IEnumerable<object> models)
        {
            throw new NotImplementedException();
        }

        private async void OnData()
        {
            IPacketReader packetReader = packetReaderFactory();
            packetReader.Read(webSocketPacket.Data);

            foreach ((MessageOpcode opcode, object model) in packetReader)
            {
                IMessageHandlerDelegate handler = messageService.GetMessageHandler(opcode);
                if (handler == null)
                {
                    logger.LogWarning($"No handler for message {opcode}!");
                    continue;
                }

                logger.LogTrace($"Handling message {opcode}...");
                try
                {
                    await handler.Invoke(this, model);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
    }
}
