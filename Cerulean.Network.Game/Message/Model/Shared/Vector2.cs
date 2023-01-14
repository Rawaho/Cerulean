using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Shared
{
    [ProtoContract]
    public class Vector2
    {
        [ProtoMember(1)]
        public float X { get; set; }

        [ProtoMember(2)]
        public float Y { get; set; }
    }
}
