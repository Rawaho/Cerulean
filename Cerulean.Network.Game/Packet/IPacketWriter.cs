using Cerulean.Network.Game.Message;

namespace Cerulean.Network.Game.Packet
{
    public interface IPacketWriter
    {
        void Add(MessageOpcode opcode, object model);

        ReadOnlyMemory<byte> Build();
    }
}
