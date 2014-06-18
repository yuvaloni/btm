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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"]!=null)
                profile.ImageUrl = "http://btm.apphb.com/Users/" + Request.QueryString["user"] + ".jpg";
        }

        protected void Logo_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Explore_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Create_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void News_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void Search_Click(object sender, ImageClickEventArgs e)
        {
            Panel2.Visible = !Panel2.Visible;
        }

        protected void profile_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["user"] != null)
                Response.Redirect("http://BeatLive.apphb.com/Profile?user=" + (string)Session["user"]);
            else
                Panel3.Visible = true;
        }

        protected void DoSearch_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void doLogin_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=2c1bdc2a-8612-479f-9158-a34b00cb2e44.sqlserver.sequelizer.com;Persist Security Info=True;User ID=uwoaeqzrkstypppn;Password=2d5wMzX4JxPTgagCtLtMRxjmUyz5pSR23jihFDYwcLxT7mHxKsM8r7VC3SKo83MZ");
            con.Open();
            SqlCommand com5 = new SqlCommand("SELECT * FROM Users WHERE username = @un AND psswd=@p AND Verified True", con);
            com5.Parameters.Add(new SqlParameter("@un", SqlDbType.VarChar)).Value = TextBox2.Text;
            com5.Parameters.Add(new SqlParameter("@p", SqlDbType.VarChar)).Value = TextBox3.Text;
            SqlDataReader R5 = com5.ExecuteReader();
            if (!R5.Read())
            {
                R5.Close();
                Response.Write("<Font color='red'>incorrect username or password</font>");
            }
            else
            {
                Session["user"] = TextBox2.Text;
                R5.Close();
                Response.Redirect("http://btm.apphb.com");
            }
        }
        protected void doRegister_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("http://btm.apphb.com/signup.aspx");
        }
        protected void closeLogin_Click(object sender, ImageClickEventArgs e)
        {
            Panel3.Visible = false;
        }

    }
}