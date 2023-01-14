namespace Cerulean.Network.Game.Message
{
    public class MessageAttribute : Attribute
    {
        public MessageOpcode Opcode { get; }
        public MessageDirection Direction { get; }

        public MessageAttribute(MessageOpcode opcode, MessageDirection direction)
        {
            Opcode = opcode;
            Direction = direction;
        }
    }
}
