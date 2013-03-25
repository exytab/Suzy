using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Suzy.Web.ajax
{
    /// <summary>
    /// Сводное описание для Common
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    [System.Web.Script.Services.ScriptService]
    public class Common : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public string HelloWorld()
        {
            return "Привет всем!";
            Session.Add("id", 4);
        }

        [WebMethod]
        public string Login(string name, string password)
        {
            //Example http://weblogs.asp.net/jalpeshpvadgama/archive/2010/08/29/calling-an-asp-net-web-service-from-jquery.aspx
            string result = string.Empty;
            try
            {
                
            }
            catch(Exception ex)
            {
                
            }
            return result;
        }
    }
}
