using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using WcfDS_FormAuth.Properties;

namespace WcfDS_FormAuth
{
    public class DSCookies
    {
        static string _cookie;

        public static string GetCookie()
        {
            string result = String.Empty;
            try
            {
                result = GetCookie(Settings.Default.UserName, Settings.Default.Pwd, Settings.Default.WcfSer4Url);
            }
            catch (ApplicationException ex )
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
            
            return result;
        }
        public static string GetCookie(string userName, string password, string wcfSer4Url)
        {
            if (_cookie == null)
            {
                string loginUri = string.Format("{0}/{1}/{2}", 
                   wcfSer4Url,
                    "Authentication_JSON_AppService.axd", //Endpoint of IIS Embedded Authentication service
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
                try
                {
                    using (StreamWriter w = new StreamWriter(request.GetRequestStream()))
                    {
                        w.Write(authBody);
                        w.Close();
                    }                    
                }
                catch (WebException webExc)
                {                    
                    throw new ApplicationException( webExc.Message);
                }
                

                using (WebResponse res = request.GetResponse())
                {
                    try
                    {
                        if (res.Headers["Set-Cookie"] != null)
                        {
                            _cookie = res.Headers["Set-Cookie"];
                        }
                        else
                        {
                            throw new SecurityException("Invalid username and password");
                        }
                    }
                    catch(Exception ex)
                    {
                        throw new ApplicationException(ex.Message);
                    }

                 }              
            }
            return _cookie;
        } 
    }
}
