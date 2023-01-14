namespace Cerulean.Network.Game.Message
{
    [Flags]
    public enum MessageDirection
    {
        None = 0x00,
        Client = 0x01,
        Server = 0x02
    }
}
