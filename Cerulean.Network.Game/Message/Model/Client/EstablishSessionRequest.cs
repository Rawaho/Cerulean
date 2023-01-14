using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Client
{
    [Message(MessageOpcode.EstablishSessionRequest, MessageDirection.Client)]
    [ProtoContract]
    public class EstablishSessionRequest
    {
        [ProtoMember(1)]
        public string Application { get; set; }

        [ProtoMember(2)]
        public string Version { get; set; }

        [ProtoMember(3)]
        public string AuthenticationToken { get; set; }

        [ProtoMember(4)]
        public long ClientTimestamp { get; set; }
    }
}
