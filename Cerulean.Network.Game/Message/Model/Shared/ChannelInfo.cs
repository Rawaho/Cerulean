using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Shared
{
    [ProtoContract]
    public class ChannelInfo
    {
        [ProtoMember(1)]
        public int ChannelId { get; set; }

        [ProtoMember(2)]
        public int Population { get; set; }
    }
}
