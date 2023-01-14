using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Client
{
    [Message(MessageOpcode.PingMessage, MessageDirection.Client)]
    [ProtoContract]
    public class PingMessage
    {
        [ProtoMember(1)]
        public long ClientTimestamp { get; set; }

        [ProtoMember(2)]
        public long ServerTimestamp { get; set; }
    }
}
