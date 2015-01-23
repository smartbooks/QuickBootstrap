using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace QuickBootstrap.Extendsions
{
    public static class ByteExtendsions
    {
        public static Image ToBitmap(this byte[] data)
        {
            var ms = new MemoryStream(data);
            return Image.FromStream(ms);
        }

        public static T To<T>(this byte[] date) where T : class
        {
            if (date == null)
            {
                return default(T);
            }

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream(date))
            {
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}
