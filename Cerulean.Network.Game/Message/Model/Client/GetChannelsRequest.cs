using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Client
{
    [Message(MessageOpcode.GetChannelsRequest, MessageDirection.Client)]
    [ProtoContract]
    public class GetChannelsRequest
    {
        [ProtoMember(1)]
        public int Skip { get; set; }

        [ProtoMember(2)]
        public int Take { get; set; }
    }
}
