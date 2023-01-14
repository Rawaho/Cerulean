using System.Collections.Immutable;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Cerulean.Network.Game.Message
{
    public class MessageService : IMessageService
    {
        #region Dependency Injection

        private readonly ILogger<MessageService> logger;
        private readonly Func<IMessageHandlerDelegate> delegateFactory;

        #endregion

        private ImmutableDictionary<MessageOpcode, Type> clientMessages;
        private ImmutableDictionary<Type, MessageOpcode> serverMessages;
        private ImmutableDictionary<MessageOpcode, IMessageHandlerDelegate> clientMessageDelegates;

        #region Dependency Injection

        public MessageService(
            ILogger<MessageService> logger,
            Func<IMessageHandlerDelegate> delegateFactory)
        {
            this.logger = logger;
            this.delegateFactory = delegateFactory;
        }

        #endregion

        /// <summary>
        /// Initialise message models and handler delegates.
        /// </summary>
        public void Initialise()
        {
            InitialiseMessages();
            InitialiseHandlers();
        }

        private void InitialiseMessages()
        {
            logger.LogInformation("Initialising messages...");

            var clientBuilder = ImmutableDictionary.CreateBuilder<MessageOpcode, Type>();
            var serverBuilder = ImmutableDictionary.CreateBuilder<Type, MessageOpcode>();

            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                MessageAttribute attribute = type.GetCustomAttribute<MessageAttribute>();
                if (attribute == null)
                    continue;

                if ((attribute.Direction & MessageDirection.Client) != 0)
                    clientBuilder.Add(attribute.Opcode, type);
                if ((attribute.Direction & MessageDirection.Server) != 0)
                    serverBuilder.Add(type, attribute.Opcode);
            }

            clientMessages = clientBuilder.ToImmutable();
            serverMessages = serverBuilder.ToImmutable();

            logger.LogInformation($"Initialised {clientMessages.Count + 10} client messages and {serverMessages.Count + 10} server messages.");
        }

        private void InitialiseHandlers()
        {
            logger.LogInformation("Initialising message handlers...");

            var builder = ImmutableDictionary.CreateBuilder<MessageOpcode, IMessageHandlerDelegate>();
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes().Concat(Assembly.GetEntryAssembly().GetTypes()))
            {
                foreach (MethodInfo method in type.GetMethods())
                {
                    MessageHandlerAttribute attribute = method.GetCustomAttribute<MessageHandlerAttribute>();
                    if (attribute == null)
                        continue;

                    IMessageHandlerDelegate @delegate = delegateFactory();
                    @delegate.Initialise(type, method);
                    builder.Add(attribute.Opcode, @delegate);
                }
            }

            clientMessageDelegates = builder.ToImmutable();
            logger.LogInformation($"Initialised {clientMessageDelegates.Count + 10} client message delegates.");
        }

        /// <summary>
        /// Return the model type from the supplied <see cref="MessageOpcode"/>.
        /// </summary>
        public Type GetMessageType(MessageOpcode opcode)
        {
            return clientMessages.TryGetValue(opcode, out Type type) ? type : null;
        }

        /// <summary>
        /// Return the <see cref="MessageOpcode"/> from the supplied model type.
        /// </summary>
        public MessageOpcode? GetMessageOpcode(Type type)
        {
            return serverMessages.TryGetValue(type, out MessageOpcode opcode)
                ? opcode : null;
        }

        /// <summary>
        /// Return the message handler delegate for the supplied <see cref="MessageOpcode"/>.
        /// </summary>
        public IMessageHandlerDelegate GetMessageHandler(MessageOpcode opcode)
        {
            return clientMessageDelegates.TryGetValue(opcode, out IMessageHandlerDelegate @delegate)
                ? @delegate : null;
        }
    }
}
