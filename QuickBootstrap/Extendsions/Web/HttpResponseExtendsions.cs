using System;
using System.IO;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace QuickBootstrap.Extendsions.Web
{
    public static class HttpResponseExtendsions
    {
        public static void WriteCsv(this HttpResponse response, string content)
        {
            using (var ms = new MemoryStream(Encoding.Default.GetBytes(content)))
            {
                response.AppendHeader("content-disposition", string.Format("attachment;filename={0}.csv", Guid.NewGuid()));
                response.ContentType = "application/ms-excel";
                response.BinaryWrite(ms.ToArray());
                response.End();
            }
        }

        public static void WriteXml<T>(this HttpResponse response, T t) where T : class
        {
            var stringBuilder = new StringBuilder();

            using (TextWriter tw = new StringWriter(stringBuilder))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(tw, t);
            }

            response.ContentType = "text/xml";
            response.Write(stringBuilder);
            response.End();
        }
    }
}
