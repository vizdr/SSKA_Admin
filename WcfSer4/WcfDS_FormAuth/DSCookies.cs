using System;
using System.IO;
using System.Net;
using System.Security;
using WcfDS_FormAuth.Properties;

namespace WcfDS_FormAuth
{
    public class DSCookies
    {
        static string _cookie;

        public static string GetCookie()
        {
            return GetCookie(Settings.Default.UserName, Settings.Default.Pwd, Settings.Default.WcfSer4Url);
        }
        public static string GetCookie(string userName, string password, string wcfSer4Url)
        {
            if (_cookie == null)
            {
                string loginUri = string.Format("{0}/{1}/{2}", // 
                   wcfSer4Url,
                    "Authentication_JSON_AppService.axd",//"",WcfSer4
                    "Login");
                WebRequest request = HttpWebRequest.Create(loginUri);
                request.Method = "POST";
                request.ContentType = "application/json";

                string authBody = String.Format(
                    "{{ \"userName\": \"{0}\", \"password\": \"{1}\", \"createPersistentCookie\":false}}",
                    userName,
                    password);
                request.ContentLength = authBody.Length;
                request.Credentials = new NetworkCredential(userName, password);
                request.UseDefaultCredentials = true;
                StreamWriter w = new StreamWriter(request.GetRequestStream());
                w.Write(authBody);
                w.Close();

                WebResponse res = request.GetResponse();
                if (res.Headers["Set-Cookie"] != null)
                {
                    _cookie = res.Headers["Set-Cookie"];
                }
                else
                {
                    throw new SecurityException("Invalid username and password");
                }
            }
            return _cookie;
        } 
    }
}
