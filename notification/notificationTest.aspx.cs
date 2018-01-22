using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace notification
{
    public partial class notificationTest : System.Web.UI.Page
    {
        
            protected void Page_Load(object sender, EventArgs e)
            {

            }


            public void test()
            {

            }

            protected void sendmessage_Click(object sender, EventArgs e)
            {
                HttpWebRequest request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

                request.KeepAlive = true;
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";

                request.Headers.Add("authorization", "Basic NGEwMGZmMjItY2NkNy0xMWUzLTk5ZDUtMDAwYzI5NDBlNjJj");

                var serializer = new JavaScriptSerializer();


                var obj = new
                {
                    app_id = "f521f6e1-16ca-40b6-b98d-c68d6379379c",
                    contents = new { en = "Test Notification" },
                    include_player_ids = new string[] { "2c071f15-c303-4497-8663-ac47a0be4cd7" }
                };



                var param = serializer.Serialize(obj);
                byte[] byteArray = Encoding.UTF8.GetBytes(param);

                string responseContent = null;

                try
                {
                    using (var writer = request.GetRequestStream())
                    {
                        writer.Write(byteArray, 0, byteArray.Length);
                    }

                    using (var response = request.GetResponse() as HttpWebResponse)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            responseContent = reader.ReadToEnd();
                        }
                    }
                }
                catch (WebException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
                }

                System.Diagnostics.Debug.WriteLine(responseContent);
            }




            protected void sendmessageBasedOnTag_Click(object sender, EventArgs e)
            {
                var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

                request.KeepAlive = true;
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";

                request.Headers.Add("authorization", "Basic NGEwMGZmMjItY2NkNy0xMWUzLTk5ZDUtMDAwYzI5NDBlNjJj");

                byte[] byteArray = Encoding.UTF8.GetBytes("{"
                                                        + "\"app_id\": \"f521f6e1-16ca-40b6-b98d-c68d6379379c\","
                                                        + "\"contents\": {\"en\": \"English Message\"},"
                                                        + "\"included_segments\": [\"All\"]}");

                string responseContent = null;

                try
                {
                    using (var writer = request.GetRequestStream())
                    {
                        writer.Write(byteArray, 0, byteArray.Length);
                    }

                    using (var response = request.GetResponse() as HttpWebResponse)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            responseContent = reader.ReadToEnd();
                        }
                    }
                }
                catch (WebException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
                }

                System.Diagnostics.Debug.WriteLine(responseContent);

                /* var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

                 request.KeepAlive = true;
                 request.Method = "POST";
                 request.ContentType = "application/json; charset=utf-8";

                 request.Headers.Add("authorization", "Basic NGEwMGZmMjItY2NkNy0xMWUzLTk5ZDUtMDAwYzI5NDBlNjJj");

                 var serializer = new JavaScriptSerializer();
        
                var obj = new
                 {
                     app_id = "f521f6e1-16ca-40b6-b98d-c68d6379379c",
                     contents = new { en = "send based on tags" },
                     filters = new object[] { new { field = "tag", key = "PhoneGapKey", relation = "=", value = "PhoneGapValue" } }
                 };


                 var param = serializer.Serialize(obj);
                 byte[] byteArray = Encoding.UTF8.GetBytes(param);

                 string responseContent = null;

                 try
                 {
                     using (var writer = request.GetRequestStream())
                     {
                         writer.Write(byteArray, 0, byteArray.Length);
                     }

                     using (var response = request.GetResponse() as HttpWebResponse)
                     {
                         using (var reader = new StreamReader(response.GetResponseStream()))
                         {
                             responseContent = reader.ReadToEnd();
                         }
                     }
                 }
                 catch (WebException ex)
                 {
                     System.Diagnostics.Debug.WriteLine(ex.Message);
                     System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
                 }

                 System.Diagnostics.Debug.WriteLine(responseContent);*/


            }

        
    }
}