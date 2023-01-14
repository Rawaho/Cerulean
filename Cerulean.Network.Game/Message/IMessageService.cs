namespace Cerulean.Network.Game.Message
{
    public interface IMessageService
    {
        /// <summary>
        /// Initialise message models and handler delegates.
        /// </summary>
        void Initialise();

        /// <summary>
        /// Return the model type from the supplied <see cref="MessageOpcode"/>.
        /// </summary>
        Type GetMessageType(MessageOpcode opcode);

        /// <summary>
        /// Return the <see cref="MessageOpcode"/> from the supplied model type.
        /// </summary>
        MessageOpcode? GetMessageOpcode(Type type);

        /// <summary>
        /// Return the message handler delegate for the supplied <see cref="MessageOpcode"/>.
        /// </summary>
        IMessageHandlerDelegate GetMessageHandler(MessageOpcode opcode);
    }
}
