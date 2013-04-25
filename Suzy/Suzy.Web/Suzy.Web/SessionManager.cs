using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Suzy.BO;

namespace Suzy.Web
{
    /// <summary>
    /// Класс для аутентификации и авторизации пользователей
    /// </summary>
    public static class SessionManager
    {
        public static int? Get()
        {
            return (int?)System.Web.HttpContext.Current.Session["UserID"];
        }

        public static Account GetAccount()
        {
            return AccountList.Get(Get() ?? 0);
        }

        public static void Set(int? id)
        {
            System.Web.HttpContext.Current.Session["UserID"] = id;
        }

        public static void SetAccount(Account account)
        {
            System.Web.HttpContext.Current.Session["UserID"] = account.id;
        }

        public static bool IsAuthorization()
        {
            return System.Web.HttpContext.Current.Session["UserID"] != null;
        }

        public static void Logout()
        {
            System.Web.HttpContext.Current.Session["UserID"] = null;
        }
    }
}