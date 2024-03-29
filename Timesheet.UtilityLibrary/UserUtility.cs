using Microsoft.AspNetCore.Http;
using System.Xml.Serialization;

namespace Timesheet.UtilityLibrary
{
    public class UserUtility
    {
        public static string GetIPAddress(HttpRequest httpRequest)
        {
            return httpRequest.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        public static string GetUserAgent(HttpRequest httpRequest)
        {
            return httpRequest.Headers["User-Agent"].ToString();
        }

        public static string GetXMLString(Object obj)
        {
            XmlSerializer x = new XmlSerializer(obj.GetType());
            var stringWriter = new StringWriter();
            x.Serialize(stringWriter, obj);
            var xmlStringContent = stringWriter.ToString();
            return xmlStringContent;
        }

        public static string ImageToBase64(string documentFilePath)
        {
            byte[] imageArray;
            imageArray = File.ReadAllBytes(documentFilePath);
            return Convert.ToBase64String(imageArray);
        }


    }
}
