using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Suzy.Web
{
    public static class SessionManager
    {
        public static int? Get()
        {
            return (int?)System.Web.HttpContext.Current.Session["UserID"];
        }

        public static void Set(int? id)
        {
            System.Web.HttpContext.Current.Session["UserID"] = id;
        }

        public static bool IsAuthorization()
        {
            return System.Web.HttpContext.Current.Session["UserID"] != null;
        }
    }
}