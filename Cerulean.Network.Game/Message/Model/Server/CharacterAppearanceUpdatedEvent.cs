using Cerulean.Network.Game.Message.Model.Shared;
using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Server
{
    [Message(MessageOpcode.CharacterAppearanceUpdatedEvent, MessageDirection.Server)]
    [ProtoContract]
    public class CharacterAppearanceUpdatedEvent
    {
        [ProtoMember(1)]
        public long CharacterId { get; set; }

        [ProtoMember(2)]
        public List<CharacterAppearance> Appearance { get; set; }
    }
}
