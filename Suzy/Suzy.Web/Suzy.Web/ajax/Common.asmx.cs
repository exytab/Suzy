﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using Suzy.BO;
using System.Text;
using System.IO;

namespace Suzy.Web.ajax
{
    /// <summary>
    /// Сводное описание для Common
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Common : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public string HelloWorld()
        {
            return "Привет всем!";
        }

        [WebMethod(EnableSession = true)]
        public string Login(string email, string password)
        {
            //Example http://weblogs.asp.net/jalpeshpvadgama/archive/2010/08/29/calling-an-asp-net-web-service-from-jquery.aspx
            string result = string.Empty;
            try
            {
                Account account = AccountList.Get(email);
                if (account != null)
                {
                    if(password == account.password)
                    {
                        SessionManager.SetAccount(account);

                        result = string.Format("replace:{0}", Helper.UserControlToString("SignForm.ascx"));
                    }
                    else
                    {
                        result = "alert:Wrong email or password";
                    }
                }
                else
                {
                    Account newAccount = new Account();
                    newAccount.email = email;
                    newAccount.password = password;
                    AccountList.Add(newAccount);

                    SessionManager.SetAccount(newAccount);

                    result = string.Format("replace:{0}", Helper.UserControlToString("SignForm.ascx"));
                }
            }
            catch(Exception ex)
            {
                
            }
            return result;
        }

        [WebMethod(EnableSession = true)]
        public string SavePosition(float latitude, float longitude, float radius)
        {
            string result = string.Empty;
            try
            {
                if(SessionManager.IsAuthorization())
                {
                    LocationArea la = new LocationArea();
                    la.id_account = (int)SessionManager.Get();
                    la.lattitude = latitude;
                    la.longtitude = longitude;
                    la.radius = radius;
                    la.time_of_marking = DateTime.Now;
                    
                    LocationList.Add(la);
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
