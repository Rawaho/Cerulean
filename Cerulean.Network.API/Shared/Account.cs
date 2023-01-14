namespace Cerulean.Network.API.Shared
{
    public class Account
    {
        public long AccountId { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? LastLogin { get; set; }
        public DateTimeOffset? DisabledAt { get; set; }
        public DateTimeOffset? BannedUntil { get; set; }
    }
}
