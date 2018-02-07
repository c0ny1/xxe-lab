using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Csharp_xxe.Controllers
{
    public class LoginController : Controller
    {
        private static string USERNAME = "admin";
        private static string PASSWORD = "admin";

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public void doLogin()
        {
            string result = String.Format("<result><code>{0}</code><msg>{1}</msg></result>",null,null);
            if (Request.RequestType == "POST")
            {
                try
                {
                    //接收并读取POST过来的XML文件流
                    StreamReader reader = new StreamReader(Request.InputStream);
                    String xmlData = reader.ReadToEnd();
                    var doc = new XmlDocument();
                    doc.LoadXml(xmlData);
                    XmlElement xRoot = doc.DocumentElement;

                    XmlNode uNode = xRoot.GetElementsByTagName("username")[0];
                    XmlNode pNode = xRoot.GetElementsByTagName("password")[0];

                    string username = uNode.InnerText;
                    string password = pNode.InnerText;

                    if (username.Equals(USERNAME) && password.Equals(PASSWORD))
                    {
                        result = String.Format("<result><code>{0}</code><msg>{1}</msg></result>", 1, username);
                    }
                    else
                    {
                        result = String.Format("<result><code>{0}</code><msg>{1}</msg></result>", 0, username);
                    }
                }
                catch (ArgumentException e1)
                {
                    result = String.Format("<result><code>{0}</code><msg>{1}</msg></result>", 3, e1);
                }
                catch (XmlException e2)
                {
                    result = String.Format("<result><code>{0}</code><msg>{1}</msg></result>", 3, e2);
                }
                finally
                {
                    Response.ContentType = "text/xml; charset=utf-8";
                    Response.Write(result);
                }

            }
        }
    }
}