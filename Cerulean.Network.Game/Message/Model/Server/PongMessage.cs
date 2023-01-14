using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Server
{
    [Message(MessageOpcode.PongMessage, MessageDirection.Server)]
    [ProtoContract]
    public class PongMessage
    {
        [ProtoMember(1)]
        public long ClientTimestamp { get; set; }

        [ProtoMember(2)]
        public long ServerTimestamp { get; set; }

        [ProtoMember(3)]
        public bool IsMasterClock { get; set; }
    }
}
