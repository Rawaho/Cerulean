using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Shared
{
    [ProtoContract]
    public class CharacterInfo
    {
        [ProtoMember(1)]
        public long Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public long CreatedTimestamp { get; set; }

        [ProtoMember(4)]
        public List<CharacterAppearance> Appearance { get; set; }
    }
}
