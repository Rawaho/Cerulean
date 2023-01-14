using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Shared
{
    [ProtoContract]
    public class Inventory
    {
        public enum InventoryType
        {
            None,
            General,
            CharacterEquipped
        }

        [ProtoMember(1)]
        public long InventoryId { get; set; }

        [ProtoMember(2)]
        public long OwnerId { get; set; }

        [ProtoMember(3)]
        public InventoryType Type { get; set; }

        [ProtoMember(4)]
        public List<Item> Items { get; set; }
    }
}
