namespace Cerulean.Network.Game.Packet
{
    public class WebSocketPacket : IWebSocketPacket
    {
        /// <summary>
        /// Determines if all data fragments for the message are present.
        /// </summary>
        public bool IsComplete { get; private set; }

        /// <summary>
        /// Return the complete data for the message.
        /// </summary>
        public ReadOnlyMemory<byte> Data
        {
            get
            {
                if (!IsComplete)
                    throw new InvalidOperationException();

                return stream
                    .GetBuffer()
                    .AsMemory(0, (int)stream.Position);
            }
        }

        private readonly MemoryStream stream = new MemoryStream();

        /// <summary>
        /// Write data to the message in an asynchronous fashion.
        /// </summary>
        public async Task OnDataAsync(ReadOnlyMemory<byte> data, bool endOfMessage, CancellationToken cancellationToken)
        {
            if (IsComplete)
                throw new InvalidOperationException();

            await stream.WriteAsync(data, cancellationToken);
            IsComplete = endOfMessage;
        }
    }
}
