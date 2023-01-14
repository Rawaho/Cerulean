using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Client
{
    [Message(MessageOpcode.UpdateChannelRequest, MessageDirection.Client)]
    [ProtoContract]
    public class UpdateChannelRequest
    {
        [ProtoMember(1)]
        public int ChannelId { get; set; }
    }
}
