using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace Dollars_Chat
{
    public partial class Login : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]    // Rounded Edges
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        // Move Application Around

        public const int WM_NCHITTEST = 0x84;
        public const int HT_CLIENT = 0x1;
        public const int HT_CAPTION = 0x2;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        public static string username;
        public static string Type;

        static string connectionstring = @"Data Source=AMADEUS\MSSQLSERVER01;Initial Catalog=Users;Integrated Security=True";
        SqlConnection cnn = new SqlConnection(connectionstring);

        public Login()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            username = txtUserName.Text;
            string password = txtPassword.Text;
            bool banned=false;

            // Check if banned and Find Type

            string query2 = "Select * from UserInfo Where UserName='" + username + "' and Password='" + password + "' and Banned='"+banned+"'";
            string query3= "Select Type from UserInfo Where UserName='" + username + "' and Password='" + password +"'";

            cnn.Open();
            SqlCommand cmd = new SqlCommand(query3, cnn);
            Type = Convert.ToString(cmd.ExecuteScalar());
            cnn.Close();

            SqlDataAdapter sda = new SqlDataAdapter(query2, cnn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (Convert.ToInt32(dt.Rows.Count.ToString()) == 0)
            {
                MessageBox.Show("User Doesnt Exist or Banned!");
            }

            else
            {
                Chat x = new Chat();
                x.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)  // Closs Application
        {
            Application.Exit();
        }

        private void btnCreateNew_Click_1(object sender, EventArgs e)  // Create New Account
        {
            CreateNew x = new CreateNew();
            x.Show();
            this.Hide();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)  // Press Enter to Focus txt Password
        {
            if(e.KeyCode==Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)  // Press Enter to Login
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)   // Visit official Website
        {
            System.Diagnostics.Process.Start("https://drrr.com/");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)  // Hover ToolTip
        {
            toolTip1.Show("Visit Official Dollars Website", pictureBox1);
        }
    }
}
