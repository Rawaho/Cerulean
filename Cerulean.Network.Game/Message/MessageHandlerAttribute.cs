namespace Cerulean.Network.Game.Message
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MessageHandlerAttribute : Attribute
    {
        public MessageOpcode Opcode { get; set; }

        public MessageHandlerAttribute(MessageOpcode opcode)
        {
            Opcode = opcode;
        }
    }
}
