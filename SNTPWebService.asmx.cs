using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace TestWebServiceAndDB
{
    /// <summary>
    /// SNTPWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class SNTPWebService : System.Web.Services.WebService
    {


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public List<Light> searchLightInfo()
        {
            //initial catalog = 修改成为你自己创建的数据库; Data Source = localhost;
            string connectionStr = "server=MM-PC\\SQLEXPRESS;database=SNTPDB;integrated security=SSPI";
            SqlConnection sqlconnection = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "select * from Light";
            cmd.Connection = sqlconnection;
            sqlconnection.Open();

            reader = cmd.ExecuteReader();

            List<Light> lights = new List<Light>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Light light = new Light();
                    light.LightID = reader.GetInt32(0);
                    light.date = reader.GetString(1);
                    light.LightValue = reader.GetInt32(2);
                    lights.Add(light);
                }
            }
           
            reader.Close();
            sqlconnection.Close();

            
            return lights;
        }
        
        
        [WebMethod]
        public bool verifyReCaptcha(string response)
        {

            string siteKey = "6LeO50AUAAAAADX3fY7XJu_rMk_FvvF08SZhODUe";
            string secretKey = "6LeO50AUAAAAAAwgRaoPpxVbrZ2EOrx_X5j3H1wz";
            string url = "https://www.google.com/recaptcha/api/siteverify?secret=" + secretKey + "&response=" + response;
            string result = (new WebClient()).DownloadString(url);


            return result.IndexOf("true") > 0;

        }
    }
}
