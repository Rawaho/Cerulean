using Microsoft.Extensions.Logging;

namespace Cerulean.Game.Channel
{
    public class ChannelService : IChannelService
    {
        #region Dependency Injection

        private readonly ILogger<ChannelService> logger;

        #endregion

        private readonly Dictionary<int, IChannel> channels = new Dictionary<int, IChannel>();
        private readonly ReaderWriterLockSlim mutex = new ReaderWriterLockSlim();

        #region Dependency Injection

        public ChannelService()
        {

        }

        #endregion

        public void Initialise()
        {
            for (int i = 1; i <= 5; i++)
                CreateChannel(i);
        }

        /// <summary>
        /// 
        /// </summary>
        public IChannel GetChannel(int id)
        {
            mutex.EnterReadLock();
            try
            {
                return null;
            }
            finally
            {
                mutex.ExitReadLock();
            }
        }

        private void CreateChannel(int id)
        {
            mutex.EnterWriteLock();
            try
            {
                //channels.Add(id);
            }
            finally
            {
                mutex.ExitWriteLock();
            }
        }
    }
}
