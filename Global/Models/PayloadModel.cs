using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Global.Models
{
    public class PayloadModel
    {
        // Unique User Identifier
        public Guid UserGuid;
        // Unique Match Identifier
        public Guid MatchGuid;
       

        /*
        public PayloadModel(Guid userGuid, string move, Guid matchGuid)
        {
            UserGuid = userGuid;
            Move = move;
            MatchGuid = matchGuid;
        }
        */

        public PayloadModel(Guid userGuid, Guid matchGuid)
        {
            UserGuid = userGuid;
            MatchGuid = matchGuid;
        }

        public PayloadModel()
        {
        }

        public override string ToString()
        {
            return $"User: {UserGuid.ToString()} - Match: {MatchGuid.ToString()}";
        }

        public Byte[] ToByteArray()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, this);
                return stream.ToArray();
            }
        }

        public static PayloadModel ByteArrayToPayloadModel(Byte[] obj)
        {
            using (var stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                stream.Write(obj, 0, obj.Length);
                stream.Seek(0, SeekOrigin.Begin);
                PayloadModel model = (PayloadModel)formatter.Deserialize(stream);
                return model;
            }
        }
    }
}
