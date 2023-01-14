using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Shared
{
    [ProtoContract]
    public class AccountInfo
    {
        [ProtoMember(1)]
        public long Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public long JoinedTimestamp { get; set; }

        [ProtoMember(4)]
        public long BannedUntil { get; set; }
    }
}
