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
    
    public partial class CreateNew : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]  // Rounded Edges
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // height of ellipse
          int nHeightEllipse // width of ellipse
      );
        // Move App Around

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

        int RandomCode;

        public CreateNew()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }


        public void UpdateDatabase(string UserName, string Password, int Code, int Donated_Amount, int Credit_Number, int SecNum,string Type,bool banned,int ID)
        { 
            // Insert Data into Database

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
            if (!String.IsNullOrEmpty(txtUserName.Text) && !String.IsNullOrEmpty(txtPass.Text))
            { 
             string UserName = txtUserName.Text;
            string Password = txtPass.Text;
            int Random = Convert.ToInt32(txtRNum.Text);

            if (Random!=RandomCode&&(!radioAdmin.Checked&&Random==1337)&&(radioAdmin.Checked&&Random!=1337))
            {
                MessageBox.Show("Wrong Code");

            }

            if (radioNormal.Checked && Random == RandomCode)
            {
                Global.user[Global.i] = new NormalUser(UserName, Password, Random);
                Global.i++;
                UpdateDatabase(UserName, Password, Random, 0, 0, 0, "normal",false,0);
                Login y = new Login();
                y.Show();
                this.Hide();
            }

            if (radioVIP.Checked && Random == RandomCode)
            {
                Global.user[Global.i] = new VIPUser(UserName, Password, Random);

                VIP x = new VIP();
                x.Show();
                this.Hide();

            }

                if (radioAdmin.Checked && Random == 1337)
                {
                    Global.user[Global.i] = new AdminUser(UserName, Password, Random);
                    Global.i++;
                    UpdateDatabase(UserName, Password, Random, 0, 0, 0, "admin", false, 0);

                    Login y = new Login();
                    y.Show();
                    this.Hide();
                }
            }

            else
            {
                MessageBox.Show("Please Enter User Name and Password");
            }
        }

        private void radioNormal_CheckedChanged(object sender, EventArgs e)  //Normal Radio Button
        {
            btnRandom.Enabled = true;
            btnRandom.Visible = true;
        }

        private void radioVIP_CheckedChanged(object sender, EventArgs e)  // VIP Radio Button
        {
            btnRandom.Enabled = true;
            btnRandom.Visible = true;
        }

        private void radioAdmin_CheckedChanged(object sender, EventArgs e)  // Admin Radio Button
        {
            btnRandom.Enabled = false;
            btnRandom.Visible = false;

        }

        private void txtRNum_TextChanged(object sender, EventArgs e)  // Check if Code Entered is Code Generated
        {
            string nullCheck = txtRNum.Text;
            if (nullCheck != "" )
            {
                int Random=0;
                try
                {
                    Random = Convert.ToInt32(txtRNum.Text);
                }
                catch (FormatException x)
                {
                    MessageBox.Show("Please enter a valid numeric Code");
                }

                if (Random == RandomCode || (radioAdmin.Checked && Random == 1337))
                {
                    btnCreate.Enabled = true;
                }

                else
                {
                    btnCreate.Enabled = false;
                }
            }
        }


        private void btnRandom_Click_1(object sender, EventArgs e)  //Generate Code
        {
            Random r = new Random();

            RandomCode = r.Next(1000, 10000);

            MsgBox x = new MsgBox(this);
            x.ShowMsg(RandomCode.ToString());
            x.Show();

            btnRandom.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)  //Close Application
        {
            Application.Exit();
        }

        public void FocustxtCode()
        {
            txtRNum.Focus();
        }

        private void txtUserName_KeyDown_1(object sender, KeyEventArgs e)  // Press Enter to Focus txt Password
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtRNum_KeyDown(object sender, KeyEventArgs e)  // Press Enter to Create Account
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnCreate.PerformClick();
            }
        }

        private void cheShowPass_CheckedChanged(object sender, EventArgs e)  //Show Password CheckBox
        {
            if(cheShowPass.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }

            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }

    }
}
