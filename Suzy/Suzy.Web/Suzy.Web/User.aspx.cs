using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Suzy.BO;

namespace Suzy.Web
{
    public partial class User : System.Web.UI.Page
    {
        public Account account = null;
        public List<LocationArea> locationAreas = null; // http://api.yandex.ru/maps/doc/jsapi/2.x/ref/reference/Clusterer.xml

        protected void Page_Load(object sender, EventArgs e)
        {
            //Check user
            if (RouteData.Values["userId"] != null)
            {
                int id;
                if (int.TryParse(RouteData.Values["userId"].ToString(), out id))
                {
                    Account account = AccountList.Get(id);
                    if (account != null)
                    {
                        this.account = account;
                        this.locationAreas = LocationList.GetByAccount(account.id);
                    }
                    else
                    {
                        Response.Redirect("/profile");
                    }
                }
                else
                {
                    Response.Redirect("/profile");
                }
            }
            else if (RouteData.Values["userLogin"] != null)
            {
                Account account = AccountList.GetByName(RouteData.Values["userLogin"].ToString());
                if (account != null)
                {
                    this.account = account;
                    this.locationAreas = LocationList.GetByAccount(account.id);
                }
                else
                {
                    Response.Redirect("/profile");
                }
            }
            else
            {
                Response.Redirect("/profile");
            }
            
        }
    }
}