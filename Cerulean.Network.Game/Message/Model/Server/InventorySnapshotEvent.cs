using Cerulean.Network.Game.Message.Model.Shared;
using ProtoBuf;

namespace Cerulean.Network.Game.Message.Model.Server
{
    [Message(MessageOpcode.InventorySnapshotEvent, MessageDirection.Server)]
    [ProtoContract]
    public class InventorySnapshotEvent
    {
        [ProtoMember(1)]
        public List<Inventory> Inventories { get; set; }
    }
}
