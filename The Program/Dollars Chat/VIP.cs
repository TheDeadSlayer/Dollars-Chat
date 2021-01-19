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
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace Dollars_Chat
{
    public partial class VIP : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]  //Rounded Edges
        private static extern IntPtr CreateRoundRectRgn
     (
         int nLeftRect,     // x-coordinate of upper-left corner
         int nTopRect,      // y-coordinate of upper-left corner
         int nRightRect,    // x-coordinate of lower-right corner
         int nBottomRect,   // y-coordinate of lower-right corner
         int nWidthEllipse, // height of ellipse
         int nHeightEllipse // width of ellipse
     );
        //Move App Around

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

        static string connectionstring = @"Data Source=AMADEUS\MSSQLSERVER01;Initial Catalog=Users;Integrated Security=True";
        SqlConnection cnn = new SqlConnection(connectionstring);

        public VIP()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        public void UpdateDatabase(string UserName, string Password, int Code, int Donated_Amount, int Credit_Number, int SecNum,string Type,bool banned, int ID)
        {
            //Insert VIP Data into Database

            cnn.Open();
            SqlDataAdapter data = new SqlDataAdapter();
            data.InsertCommand = new SqlCommand("INSERT INTO UserInfo(UserName,Password,VerificationCode,DonatedAmount,CreditCardNumber,SecurityNumber,Type,Banned) VALUES('" + UserName + "','" + Password + "','" + Code + "','" + Donated_Amount + "','" + Credit_Number + "','" + SecNum + "','"+Type+"','"+banned+"')");
            data.InsertCommand.Connection = cnn;

            try
            {
                data.InsertCommand.ExecuteNonQuery();
            }
            catch (SqlException exception)
            {
                int duplicateKey = ID; // if !null value
                MessageBox.Show(exception.Message);
            }
            cnn.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)  //Create Account
        {
            VIPUser x = Global.user[Global.i] as VIPUser;

                x.creditCardNum = Convert.ToInt32(txtCreditNum.Text);
                x.SecurityNum = Convert.ToInt32(txtSecNum.Text);
                x.DonatedAmount = Convert.ToInt32(txtDonated.Text);
                 Global.i++;


           UpdateDatabase(x.UserName, x.Password, x.Code, x.creditCardNum, x.SecurityNum, x.DonatedAmount,"vip",false,0);
            Login y = new Login();
            y.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)  //Close Application
        {
            Application.Exit();
        }

        private void txtCreditNum_KeyDown(object sender, KeyEventArgs e)  //Press Enter to Focus txt Security Num
        {
            if(e.KeyCode==Keys.Enter)
            {
                txtSecNum.Focus();
            }
        }

        private void txtSecNum_KeyDown(object sender, KeyEventArgs e)  //Press Enter to Focus txt Donated Amount
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDonated.Focus();
            }
        }

        private void txtDonated_KeyDown(object sender, KeyEventArgs e)  //Press Enter to Create Account
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreate.PerformClick();
            }
        }
    }
}
