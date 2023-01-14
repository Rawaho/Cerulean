using Cerulean.Network.Game.Message;

namespace Cerulean.Network.Game.Packet
{
    public interface IPacketReader : IEnumerable<KeyValuePair<MessageOpcode, object>>
    {
        /// <summary>
        /// 
        /// </summary>
        void Read(ReadOnlyMemory<byte> data);
    }
}
