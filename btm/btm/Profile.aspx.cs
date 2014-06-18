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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Image1.ImageUrl = "http://btm.apphb.com/Users/" + Request.QueryString["user"]+".jpg";
            SqlConnection con = new SqlConnection("Data Source=2c1bdc2a-8612-479f-9158-a34b00cb2e44.sqlserver.sequelizer.com;Persist Security Info=True;User ID=uwoaeqzrkstypppn;Password=2d5wMzX4JxPTgagCtLtMRxjmUyz5pSR23jihFDYwcLxT7mHxKsM8r7VC3SKo83MZ");
            con.Open();
            SqlCommand com5 = new SqlCommand("SELECT * FROM Users WHERE username = @un AND Verified True", con);
            com5.Parameters.Add(new SqlParameter("@un", SqlDbType.VarChar)).Value = (string)Session["user"];
            SqlDataReader R5 = com5.ExecuteReader();
            if (!R5.Read())
            {
                R5.Close();
                throw new Exception();
            }
            R5.Close();
            SqlCommand com = new SqlCommand("SELECT * FROM " + Request.QueryString["user"] + " WHERE created='YES'", con);
            SqlDataReader r = com.ExecuteReader();
            for(int i =0;r.Read();i++)
            {
                SongItem song = new SongItem(r.GetString(1));
                string id = r.GetString(0);
                song.Click += new EventHandler((object s, EventArgs ee) => { Response.Redirect("http://btm.apphb.com/Song?name=" + id); });
                Panel1.Controls.Add(song);
            }
            r.Close();
            SqlCommand com2 = new SqlCommand("SELECT * FROM " + Request.QueryString["user"] + " WHERE created='NO'", con);
            SqlDataReader r2 = com.ExecuteReader();
            for (int i = 0; r2.Read(); i++)
            {
                SongItem song = new SongItem(r2.GetString(1));
                string id = r2.GetString(0);
                song.Click += new EventHandler((object s, EventArgs ee) => { Response.Redirect("http://btm.apphb.com/Song?name=" + id); });
                Panel2.Controls.Add(song);
            }
            r2.Close();
            SqlCommand com4 = new SqlCommand("SELECT * FROM Users Where username=@u", con);
            com4.Parameters.Add(new SqlParameter("@u", SqlDbType.VarChar)).Value = Request.QueryString["user"];
            SqlDataReader r4 = com4.ExecuteReader();
            if (r4.Read())
            {
                Label1.Text = r4.GetString(2);
                Label3.Text = r4.GetString(3);
            }
            r4.Close();
            con.Close();
 
             
        }


    }
}