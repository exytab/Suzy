using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Suzy.Web
{
    public static class Helper
    {
        public static string UserControlToString(string controlPath)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter stWriter = new StringWriter(sb);
            HtmlTextWriter htmlWriter = new HtmlTextWriter(stWriter);
            Page page = new Page();
            SignForm signForm = (SignForm)page.LoadControl(controlPath);
            signForm.RenderControl(htmlWriter);
            return sb.ToString();
        }

        public static void RedirectRoot(HttpResponse Response)
        {
            Response.Redirect("/");
        }

        public static string PointToString(float? point)
        {
            return point.ToString().Replace(",", ".");
        }
    }
}