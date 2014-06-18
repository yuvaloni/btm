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
    public partial class CreateSong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Directory.Exists(Path.Combine(Server.MapPath("~"), "Songs")))
                Directory.CreateDirectory(Path.Combine(Server.MapPath("~"), "Songs"));
            if (Session["user"] == null)
                Response.Redirect("http://btm.apphb.com/login.aspx?ref=CreateSong");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=2c1bdc2a-8612-479f-9158-a34b00cb2e44.sqlserver.sequelizer.com;Persist Security Info=True;User ID=uwoaeqzrkstypppn;Password=2d5wMzX4JxPTgagCtLtMRxjmUyz5pSR23jihFDYwcLxT7mHxKsM8r7VC3SKo83MZ");
            con.Open();
            SqlCommand com2 = new SqlCommand("Select * form "+(string)Session["user"]+" WHERE name=@n AND Create='YES'", con);
            com2.Parameters.Add(new SqlParameter("@n", SqlDbType.VarChar)).Value = TextBox1.Text;
            SqlDataReader r2 = com2.ExecuteReader();
            if (r2.Read())
                Response.Write("<br/><Font color='red'/>You can't create the same song twice!</font>");
            else
            {
                int max = 0;
                SqlCommand com1 = new SqlCommand("Select * form Songs", con);
                SqlDataReader r = com1.ExecuteReader();
                while (r.Read())
                {
                    max = Math.Max(max, int.Parse(r.GetString(0)));
                }
                r.Close();
                SqlCommand com3 = new SqlCommand("INSERT INTO Songs(ID,name,Artist,rating,raters) VALUES(@i,@n@a,'0','0')", con);
                com3.Parameters.Add(new SqlParameter("@n", SqlDbType.VarChar)).Value = TextBox1.Text;
                com3.Parameters.Add(new SqlParameter("@i", SqlDbType.VarChar)).Value = max.ToString();
                com3.Parameters.Add(new SqlParameter("@a", SqlDbType.VarChar)).Value = (string)Session["user"];
                com3.ExecuteNonQuery();
                SqlCommand com4 = new SqlCommand("INSERT INTO "+(string)Session["user"]+"(ID,name,Artist,rating,raters) VALUES(@i,@n@a,'0','0')", con);
                com4.Parameters.Add(new SqlParameter("@n", SqlDbType.VarChar)).Value = TextBox1.Text;
                com4.Parameters.Add(new SqlParameter("@i", SqlDbType.VarChar)).Value = max.ToString();
                com4.Parameters.Add(new SqlParameter("@a", SqlDbType.VarChar)).Value = (string)Session["user"];
                com4.ExecuteNonQuery();
                Directory.CreateDirectory(Path.Combine(Server.MapPath("~"), "Songs",max.ToString()));
                Response.Redirect("http://btm.apphb.com/songstudio");
                
            }

            
        }
    }
}