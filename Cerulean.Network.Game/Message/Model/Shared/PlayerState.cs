using Cerulean.Game.Abstract.Entity;
using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Shared
{
    [ProtoContract]
    public class PlayerState
    {
        [ProtoMember(1)]
        public Vector2 Position { get; set; }

        [ProtoMember(2)]
        public FacingDirection FacingDirection { get; set; }

        [ProtoMember(3)]
        public long DataId { get; set; }

        [ProtoMember(4)]
        public MoveType MoveType { get; set; }

        [ProtoMember(5)]
        public long GameSessionId { get; set; }

        [ProtoMember(6)]
        public long AccountId { get; set; }

        [ProtoMember(7)]
        public long CharacterId { get; set; }

        [ProtoMember(8)]
        public string DisplayName { get; set; }

        [ProtoMember(9)]
        public List<CharacterAppearance> Appearance { get; set; }

        [ProtoMember(10)]
        public int DanceIndex { get; set; }

        [ProtoMember(11)]
        public int TimeToLive { get; set; }

        [ProtoMember(12)]
        public long LastKeepAlive { get; set; }

        [ProtoMember(13)]
        public long LastMove { get; set; }

        [ProtoMember(14)]
        public long LastTeleport { get; set; }

        [ProtoMember(15)]
        public long LastChannelUpdate { get; set; }

        [ProtoMember(16)]
        public long LastApperanceUpdate { get; set; }
    }
}
