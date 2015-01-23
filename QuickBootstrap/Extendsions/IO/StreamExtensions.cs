using System.IO;

namespace QuickBootstrap.Extendsions.IO
{
    public static class StreamExtensions
    {
        public static byte[] ToByteArray(this Stream stream)
        {
            var buffer = new byte[stream.Length];

            stream.Read(buffer, 0, buffer.Length);

            stream.Seek(0, SeekOrigin.Begin);

            return buffer;
        }
    }
}
