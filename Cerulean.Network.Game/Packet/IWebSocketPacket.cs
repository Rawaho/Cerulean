namespace Cerulean.Network.Game.Packet
{
    public interface IWebSocketPacket
    {
        /// <summary>
        /// Determines if all data fragments for the message are present.
        /// </summary>
        bool IsComplete { get; }

        /// <summary>
        /// Return the complete data for the message.
        /// </summary>
        ReadOnlyMemory<byte> Data { get; }

        /// <summary>
        /// Write data to the message in an asynchronous fashion.
        /// </summary>
        Task OnDataAsync(ReadOnlyMemory<byte> data, bool endOfMessage, CancellationToken cancellationToken);
    }
}
