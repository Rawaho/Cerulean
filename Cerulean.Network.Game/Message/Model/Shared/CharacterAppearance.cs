using Cerulean.Game.Abstract.Entity;
using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Shared
{
    [ProtoContract]
    public class CharacterAppearance
    {
        [ProtoMember(1)]
        public CharacterAppearancePart Part { get; set; }

        [ProtoMember(2)]
        public long Value { get; set; }
    }
}
