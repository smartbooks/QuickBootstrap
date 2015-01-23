using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace QuickBootstrap.Extendsions
{
    public static class ImageExtendsions
    {
        public static byte[] ToImageBytes(this Image bitmap)
        {
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
    }
}