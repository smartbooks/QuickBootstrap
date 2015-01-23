using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace QuickBootstrap.Extendsions
{
    public static class ObjectExtendsions
    {
        public static byte[] ToObjectBytes<T>(this T t) where T : class
        {
            if (t == null)
            {
                return null;
            }

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, t);
                return memoryStream.ToArray();
            }
        }
    }
}
