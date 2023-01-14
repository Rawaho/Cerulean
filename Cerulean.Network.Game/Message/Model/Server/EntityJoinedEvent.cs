using Cerulean.Network.Game.Message.Model.Shared;
using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Server
{
    [Message(MessageOpcode.EntityJoinedEvent, MessageDirection.Server)]
    [ProtoContract]
    public class EntityJoinedEvent
    {
        [ProtoMember(1)]
        public long EntityId { get; set; }

        [ProtoMember(2)]
        public WrappedEntityState EntityState { get; set; }
    }
}
