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
    public partial class VIPUserChatUI_1 : Global_UI_Class
    {
        public VIPUserChatUI_1()
        {
            InitializeComponent();
        }

        public VIPUserChatUI_1(string message)
        {
            InitializeComponent();
            lblmsg.Text = message;
            lblUserName.Text = Login.username;


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
