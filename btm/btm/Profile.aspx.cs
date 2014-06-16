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
            SqlCommand com = new SqlCommand("SELECT * FROM " + Request.QueryString["user"] + " WHERE created='YES'", con);
            SqlDataReader r = com.ExecuteReader();
            for(int i =0;r.Read();i++)
            {
                SongItem song = new SongItem(r.GetString(1));
                song.Click += new EventHandler((object s, EventArgs ee) => { Response.Redirect("http://btm.apphb.com/Song?name=" + song.name); });
                Panel1.Controls.Add(song);
            }
            r.Close();
            com = new SqlCommand("SELECT * FROM " + Request.QueryString["user"] + " WHERE created='NO'", con);
            r = com.ExecuteReader();
            for (int i = 0; r.Read(); i++)
            {
                SongItem song = new SongItem(r.GetString(1));
                song.Click += new EventHandler((object s, EventArgs ee) => { Response.Redirect("http://btm.apphb.com/Song?name=" + song.name); });
                Panel2.Controls.Add(song);
            }
            r.Close();
            com = new SqlCommand("SELECT * FROM Users Where username=@u", con);
            com.Parameters.Add(new SqlParameter("@u", SqlDbType.VarChar)).Value = Request.QueryString["user"];
            r = com.ExecuteReader();
            if (r.Read())
            {
                Label1.Text = r.GetString(2);
                Label3.Text = r.GetString(2);
            }
            r.Close();
            con.Close();
 
             
        }


    }
}