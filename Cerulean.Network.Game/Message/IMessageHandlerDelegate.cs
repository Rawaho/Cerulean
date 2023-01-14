using System.Reflection;

namespace Cerulean.Network.Game.Message
{
    public interface IMessageHandlerDelegate
    {
        /// <summary>
        /// Initialise the message handler delegate with the service and method to call on invoke.
        /// </summary>
        void Initialise(Type type, MethodInfo method);

        /// <summary>
        /// Invoke the message handler delegate, calling the underlying method to handle the message.
        /// </summary>
        Task Invoke(IGameSession session, object model);
    }
}
