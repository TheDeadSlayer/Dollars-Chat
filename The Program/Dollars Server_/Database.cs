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
using System.Runtime.InteropServices;

namespace Dollars_Server_
{
    public partial class Database : Form
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
        public Database()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Form2_Load(object sender, EventArgs e)  //Load Database
        {
            // TODO: This line of code loads data into the 'usersDataSet1.UserInfo' table. You can move, or remove it, as needed.
            this.userInfoTableAdapter.Fill(this.usersDataSet1.UserInfo);
        }

        private void btnUpdate_Click(object sender, EventArgs e)  //Update Database
        {
            userInfoTableAdapter.Update(this.usersDataSet1.UserInfo);

            RefreshDataBase();
        }

        private void btnDelete_Click(object sender, EventArgs e)  //Delete Row From Database
        {
            int ID = -1;
            try
            {
                ID = Convert.ToInt32(txtDRow.Text);
            }

            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (ID != -1)
            {
                //Serach for user according to ID

                string Query = "DELETE FROM UserInfo WHERE ID=@id;";
                using (cnn = new SqlConnection(connectionstring))
                using (SqlCommand command = new SqlCommand(Query, cnn))
                {
                    cnn.Open();

                    command.Parameters.AddWithValue("@id", ID);

                    command.ExecuteScalar();

                }
                RefreshDataBase();
            }

            else
            {
                MessageBox.Show("Input a Valid ID Number !!");
            }
        }

        void RefreshDataBase()  //Refresh Database
        {
            try
            {
                this.userInfoTableAdapter.Refresh__(this.usersDataSet1.UserInfo);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) // Close Database
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e) //Minimize
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtDRow_KeyDown(object sender, KeyEventArgs e)  // Press Enter to Delete
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnDelete.PerformClick();
            }
        }
    }
}
