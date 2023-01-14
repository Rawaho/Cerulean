using Cerulean.Network.Game.Message.Model.Shared;
using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Server
{
    [Message(MessageOpcode.GetChannelsResponse, MessageDirection.Server)]
    [ProtoContract]
    public class GetChannelsResponse
    {
        [ProtoMember(1)]
        public List<ChannelInfo> Channels { get; set; }
    }
}
