using Cerulean.Network.Game.Message.Model.Shared;
using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Server
{
    [Message(MessageOpcode.GameSessionOpenedEvent, MessageDirection.Server)]
    [ProtoContract]
    public class GameSessionOpenedEvent
    {
        [ProtoMember(1)]
        public long AccountId { get; set; }

        [ProtoMember(2)]
        public long CharacterId { get; set; }

        [ProtoMember(3)]
        public long EntityId { get; set; }

        [ProtoMember(4)]
        public WrappedEntityState EntityState { get; set; }

        [ProtoMember(5)]
        public int ChannelId { get; set; }

        [ProtoMember(6)]
        public int MapId { get; set; }
    }
}
