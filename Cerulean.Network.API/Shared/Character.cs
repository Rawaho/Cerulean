namespace Cerulean.Network.API.Shared
{
    public class Character
    {
        public long AccountId { get; set; }
        public long CharacterId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
