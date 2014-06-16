using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.IO;

namespace btm
{
    public partial class UpdatePicture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("http://btm.apphb.com/login.aspx?ref=UpdatePicture");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if(FileUpload1.FileName.Split('.')[1]!="jpg")
                Response.Write("<br/><Font color='red'/>picture format must be jpg</font>");
            else
            {
                File.WriteAllBytes(Path.Combine(Server.MapPath("~"), "Users", (string)Session["User"]+".jpg"), FileUpload1.FileBytes);
                Response.Write("Success!");
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}