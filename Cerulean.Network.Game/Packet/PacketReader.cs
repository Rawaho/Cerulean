using System.Collections;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using Cerulean.Network.Game.Message;
using Microsoft.Extensions.Logging;
using ProtoBuf;

namespace Cerulean.Network.Game.Packet
{
    public class PacketReader : IPacketReader
    {
        #region Dependency Injection

        private readonly ILogger<PacketReader> logger;
        private readonly IMessageService messageService;
        
        #endregion

        private ImmutableDictionary<MessageOpcode, object> messages;

        #region Dependency Injection

        public PacketReader(
            ILogger<PacketReader> logger,
            IMessageService messageService)
        {
            this.logger         = logger;
            this.messageService = messageService;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void Read(ReadOnlyMemory<byte> data)
        {
            try
            {
                var builder = ImmutableDictionary.CreateBuilder<MessageOpcode, object>();

                int offset = 0;
                while (data.Length - offset > 0)
                {
                    if (data.Length - offset < 8)
                        throw new InvalidDataException("Packet message header is malformed!");

                    // message header
                    var opcode = (MessageOpcode)ReadInt(data, ref offset);
                    int length = ReadInt(data, ref offset);

                    if (data.Length - offset < length)
                        throw new InvalidDataException("Packet message data is malformed!");

                    Type type = messageService.GetMessageType(opcode);
                    if (type == null)
                        throw new InvalidDataException($"Unable to parse packet message data, unknown opcode {opcode}!");

                    object model = Serializer.NonGeneric.Deserialize(type, Slice(data, ref offset, length));
                    builder.Add(opcode, model);
                }

                messages = builder.ToImmutable();
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "An exception occured while parsing packet!");
            }
        }

        private static ReadOnlyMemory<byte> Slice(ReadOnlyMemory<byte> data, ref int start, int length)
        {
            ReadOnlyMemory<byte> slice = data.Slice(start, length);
            start += length;
            return slice;
        }

        private static int ReadInt(ReadOnlyMemory<byte> data, ref int start)
        {
            ReadOnlyMemory<byte> slice = Slice(data, ref start, sizeof(int));
            return MemoryMarshal.Read<int>(slice.Span);
        }

        public IEnumerator<KeyValuePair<MessageOpcode, object>> GetEnumerator()
        {
            return messages?.GetEnumerator() ?? Enumerable.Empty<KeyValuePair<MessageOpcode, object>>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
