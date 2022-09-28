using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dollars_Chat
{
    public partial class Kicked_UI : Global_UI_Class
    {
        
        public Kicked_UI()
        {
            InitializeComponent();
            lblmsg.Text = ">> @" + Login.username + " Kicked.";


            SetHeight();

        }


        void SetHeight()
        {
            Size maxSize = new Size(495, int.MaxValue);
            Graphics g = CreateGraphics();
            SizeF size = g.MeasureString(lblmsg.Text, lblmsg.Font, lblmsg.Width);

        }

        private void lblmsg_Resize(object sender, EventArgs e)
        {
            SetHeight();
        }

    }
}
