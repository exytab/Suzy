using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using Suzy.BO;

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

        public static void RedirectRoot(HttpResponse response)
        {
            Redirect(response, "/");
        }

        public static void RedirectProfile(HttpResponse response)
        {
            Redirect(response, "/profile");
        }

        public static void Redirect(HttpResponse response, String page)
        {
            response.Redirect(page);
        }

        public static string PointToString(float? point)
        {
            return point.ToString().Replace(",", ".");
        }

        public static string UserURL(Account account)
        {
            if (string.IsNullOrEmpty(account.name))
                return string.Format("/user/id/{0}", account.id);
            else
                return string.Format("/user/{0}", account.name);
        }

        public static bool CheckAvatar(string AvatarFile)
        {
            string Path = AvatarPath(AvatarFile);
            return !System.IO.File.Exists(Path);
        }

        public static void SaveFile(HttpPostedFile File, String FileName)
        {
            string Path = string.Format("{0}/avatars/{1}", HttpRuntime.AppDomainAppPath, FileName);
            File.SaveAs(Path);
        }

        public static string AvatarPath(string AvatarFile)
        {
            return string.Format("{0}/avatars/{1}", HttpRuntime.AppDomainAppPath, AvatarFile);
        }

        public static string AvatarWebPath(string AvatarFile)
        {
            return string.Format("/avatars/{0}", AvatarFile);
        }
    }
}