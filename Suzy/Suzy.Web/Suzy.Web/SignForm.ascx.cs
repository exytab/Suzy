using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Suzy.Web
{
    public partial class SignForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if (Session["id"] == null) // if not login
             {
                 
             } 
             else
             {
                 
             }
        }
    }
}