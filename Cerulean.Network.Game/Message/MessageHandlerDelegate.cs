using System.Linq.Expressions;
using System.Reflection;

namespace Cerulean.Network.Game.Message
{
    public class MessageHandlerDelegate : IMessageHandlerDelegate
    {
        #region Dependancy Injection

        private readonly IServiceProvider serviceProvider;

        #endregion

        private delegate Task HandlerDelegate(object instance, IGameSession session, object model);

        private Type serviceType;
        private HandlerDelegate handlerDelegate;

        #region Dependancy Injection

        public MessageHandlerDelegate(
            IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        #endregion

        /// <summary>
        /// Initialise the message handler delegate with the service and method to call on invoke.
        /// </summary>
        public void Initialise(Type type, MethodInfo method)
        {
            serviceType = type;

            // check signature of the method
            ParameterInfo[] parameters = method.GetParameters();
            if (parameters.Length != 2)
                throw new ArgumentException();

            if (!typeof(IGameSession).IsAssignableFrom(parameters[0].ParameterType))
                throw new ArgumentException();

            // create delegate
            ParameterExpression instanceParameter = Expression.Parameter(typeof(object));
            ParameterExpression sessionParameter = Expression.Parameter(typeof(IGameSession));
            ParameterExpression modelParameter = Expression.Parameter(typeof(object));

            MethodCallExpression handlerCall = Expression.Call(
                Expression.Convert(instanceParameter, type),
                method,
                sessionParameter,
                Expression.Convert(modelParameter, parameters[1].ParameterType));

            Expression<HandlerDelegate> handlerLambda = Expression.Lambda<HandlerDelegate>(
                handlerCall, instanceParameter, sessionParameter, modelParameter);
            handlerDelegate = handlerLambda.Compile();
        }

        /// <summary>
        /// Invoke the message handler delegate, calling the underlying method to handle the message.
        /// </summary>
        public async Task Invoke(IGameSession session, object model)
        {
            object service = serviceProvider.GetService(serviceType);
            if (service == null)
                throw new InvalidOperationException();

            await handlerDelegate.Invoke(service, session, model);
        }
    }
}
