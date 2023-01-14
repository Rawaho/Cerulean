using Cerulean.Game.Abstract.Entity;
using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Shared
{
    [ProtoContract]
    public class WrappedEntityState
    {
        [ProtoMember(1)]
        public EntityType Type { get; set; }

        [ProtoMember(2)]
        public byte[] Data { get; set; }
    }
}
