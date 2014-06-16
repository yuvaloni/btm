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
namespace btm
{
    public partial class Verify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"];
            SqlConnection con = new SqlConnection("Data Source=2c1bdc2a-8612-479f-9158-a34b00cb2e44.sqlserver.sequelizer.com;Persist Security Info=True;User ID=uwoaeqzrkstypppn;Password=2d5wMzX4JxPTgagCtLtMRxjmUyz5pSR23jihFDYwcLxT7mHxKsM8r7VC3SKo83MZ");
            con.Open();
            SqlCommand gm = new SqlCommand("Select * from Users Where email=@e",con);
            gm.Parameters.Add(new SqlParameter("@e", SqlDbType.VarChar)).Value = email;
            SqlDataReader r = gm.ExecuteReader();
            if (r.Read())
            {
                Session["user"] = r.GetString(0);
                r.Close();
                SqlCommand gm2 = new SqlCommand("UPDATE Users SET Verified='True' Where email=@e",con);
                gm2.Parameters.Add(new SqlParameter("@e", SqlDbType.VarChar)).Value = email;
                gm2.ExecuteNonQuery();
                
            }
            else
            {
                
            }
            if(!r.IsClosed)
                r.Close();
            con.Close();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Http://btm.apphb.com/UpdatePicture.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}