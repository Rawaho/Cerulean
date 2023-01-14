using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Server
{
    [Message(MessageOpcode.UpdateChannelResponse, MessageDirection.Server)]
    [ProtoContract]
    public class UpdateChannelResponse
    {
        public enum ErrorCode
        {
            None,
            InvalidChannelId,
            ChannelFull
        }

        [ProtoMember(1)]
        public bool Success { get; set; }

        [ProtoMember(2)]
        public ErrorCode Error { get; set; }
    }
}
