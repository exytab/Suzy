using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Suzy.BO;

namespace Suzy.Web
{
    public partial class Followers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionManager.IsAuthorization())
                Helper.RedirectRoot(Response);
            else
                Users.Accounts = AccountList.GetFollowers((int)SessionManager.Get());
        }
    }
}