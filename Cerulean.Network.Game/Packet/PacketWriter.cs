using Cerulean.Network.Game.Message;
using ProtoBuf;

namespace Cerulean.Network.Game.Packet
{
    public class PacketWriter : IPacketWriter
    {
        #region Dependency Injection




        #endregion

        private List<(MessageOpcode, object)> models = new List<(MessageOpcode, object)>();
        private readonly object mutex = new object();

        #region Dependency Injection

        public PacketWriter()
        {

        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void Add(MessageOpcode opcode, object model)
        {
            models.Add((opcode, model));
        }

        /// <summary>
        /// 
        /// </summary>
        public ReadOnlyMemory<byte> Build()
        {
            using var stream = new MemoryStream();
            using var writer = new BinaryWriter(stream);



            foreach ((MessageOpcode opcode, object model) in models)
            {
                using var modelStream = new MemoryStream();
                Serializer.NonGeneric.Serialize(modelStream, model);

                writer.Write((int)opcode);
                writer.Write((int)modelStream.Position);

                modelStream.Position = 0;
                modelStream.CopyTo(stream);
            }

            return stream.ToArray();
        }
    }
}
