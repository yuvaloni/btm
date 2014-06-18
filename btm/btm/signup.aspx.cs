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
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        public void ImageButton1_Click(object sender, EventArgs e)
        {
            if(!Page.IsValid)
            {
                Response.Write("<br/><Font color='red'/>wrong captcha, try again</font>");
            }
            else if(TextBox2.Text!=TextBox3.Text)
            {
                Response.Write("<br/><Font color='red'/>passwords not matching</font>");
            }
            else if(TextBox5.Text.IndexOf('@')==-1 ||TextBox5.Text.IndexOf('.')==-1)
            {
                Response.Write("<br/><Font color='red'/>invalud email</font>");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=2c1bdc2a-8612-479f-9158-a34b00cb2e44.sqlserver.sequelizer.com;Persist Security Info=True;User ID=uwoaeqzrkstypppn;Password=2d5wMzX4JxPTgagCtLtMRxjmUyz5pSR23jihFDYwcLxT7mHxKsM8r7VC3SKo83MZ");
                con.Open();
                bool isvalid = true;
                SqlCommand com = new SqlCommand("Select * from Users",con);
                SqlDataReader reader = com.ExecuteReader();
                while(reader.Read())
                {
                    if (TextBox1.Text == reader.GetString(0))
                        isvalid = false;
                    Response.Write("<br/><Font color='red'/>username already taken</font>");
                    if (TextBox5.Text == reader.GetString(4))
                        isvalid = false;
                    Response.Write("<br/><Font color='red'/>email already in use</font>");
                }
                reader.Close();
                if(isvalid)
                {
                    com = new SqlCommand("INSERT INTO Users(username ,psswd , fullname ,instruments , email,verified) VALUES(@un,@p,@fn,@i,@e,'false')",con);
                    com.Parameters.Add(new SqlParameter("@un", System.Data.SqlDbType.VarChar)).Value = TextBox1.Text;
                    com.Parameters.Add(new SqlParameter("@p", System.Data.SqlDbType.VarChar)).Value = TextBox2.Text;
                    com.Parameters.Add(new SqlParameter("@fn", System.Data.SqlDbType.VarChar)).Value = TextBox4.Text;
                    com.Parameters.Add(new SqlParameter("@e", System.Data.SqlDbType.VarChar)).Value = TextBox5.Text;
                    com.Parameters.Add(new SqlParameter("@i", System.Data.SqlDbType.VarChar)).Value = TextBox6.Text;
                    com.ExecuteNonQuery();
                    com = new SqlCommand("Create Table " + TextBox1.Text + "(id varchar(255),name varchar(255), created varchar(255))", con);
                    com.ExecuteNonQuery();
                    using(SmtpClient S = new SmtpClient())
                    {
                        S.EnableSsl = true;
                        S.Host = "smtp.mandrillapp.com";
                        S.UseDefaultCredentials = false;
                        S.Credentials = new NetworkCredential("btm.socialmusic@gmail.com", "rvL5zTS3xBAqtRGsW8V9ow");
                        S.Port = 587;
                        MailMessage m = new MailMessage(new MailAddress("btm.socialmusic@gmail.com", "BTM Social Music"), new MailAddress(TextBox5.Text));
                        m.Subject = "Confirm you registration to BTM";
                        m.IsBodyHtml = true;
                        m.Body = "hello <br/> please click the following link or copy it to the adress line of you web browser to complete the registeration <br/> http://btm.apphb.com/Verify.aspx?email=" + TextBox5.Text + " <br/> hope to see you soon <br/> BTM Social music";
                        S.Send(m);
                         
                    }
                    con.Close();
                    Response.Redirect("http://btm.apphb.com/SignUpConfirm.aspx");

                }
            }
        }


    }
}