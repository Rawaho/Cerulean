using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Shared
{
    [ProtoContract]
    public class Item
    {
        [ProtoMember(1)]
        public long InventoryItemId { get; set; }

        [ProtoMember(2)]
        public int ItemId { get; set; }

        [ProtoMember(3)]
        public int Quantity { get; set; }
    }
}
