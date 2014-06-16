using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace btm
{
    public partial class SongItem : System.Web.UI.UserControl
    {
        public string name
        {
            get { return Button1.Text; }
        }
        public event EventHandler Click;
        public SongItem(string name)
        {
            Button1.Text = name;
            
        }
        public SongItem()
        {
            Button1.Text = name;

        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.BackColor = System.Drawing.Color.Aqua;
            Click(this, EventArgs.Empty);

        }
       
    }
}