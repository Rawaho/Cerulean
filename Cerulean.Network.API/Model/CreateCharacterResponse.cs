using Cerulean.Network.API.Shared;

namespace Cerulean.Network.API.Model
{
    public class CreateCharacterResponse
    {
        public enum ErrorCode
        {
            None,
            InvalidName,
            NameTaken,
            InvalidItemList,
            DatabaseError,
            InventoryError,
            ServiceError
        }

        public ErrorCode Error { get; set; }
        public Character Character { get; set; }
    }
}
