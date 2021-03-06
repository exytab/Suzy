﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Suzy.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.SetData("SQLServerCompactEditionUnderWebHosting", true);
            Suzy.Logger.Logg.er.Start(string.Format("{0}/log", Helper.AppPath()));
            Suzy.BO.Helper.Init();
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            Logger.Logg.er.End();
        }

        void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "profile",
                "profile",
                "~/Profile.aspx"
                );
            routes.MapPageRoute(
                "users",
                "users",
                "~/Users.aspx"
            );
            routes.MapPageRoute(
                "followings",
                "followings",
                "~/Followings.aspx"
            );
            routes.MapPageRoute(
                "followers",
                "followers",
                "~/Followers.aspx"
            );
            routes.MapPageRoute(
                "user",
                "user/{userLogin}",
                "~/User.aspx"
            );
            routes.MapPageRoute(
                "userId",
                "user/id/{userId}",
                "~/User.aspx"
            );
        }
    }
}