using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Suzy.Web
{
    public partial class AvatarUpload : System.Web.UI.Page
    {
        private static string[] ImageFileTypes = new string[]
                                                    {
                                                        "image/bmp",
                                                        "image/gif",
                                                        "image/jpeg",
                                                        "image/png"
                                                    };

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Files.Count > 0 && SessionManager.IsAuthorization())
            {
                HttpPostedFile File = Request.Files[0];
                if(ImageFileTypes.Contains(File.ContentType))
                {
                    String FileName = Helper.CheckAvatar(File.FileName)
                                          ? File.FileName
                                          : Guid.NewGuid().ToString() + File.FileName;

                    Helper.SaveFile(File, FileName);

                    SessionManager.GetAccount().SaveAvatar(FileName);
                }
            }

            Helper.RedirectProfile(Response);
        }


    }
}