using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTcp;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Dollars_Server_
{
    public partial class Server : Form
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


        string username;
        string msg;
        int index;
        int userCounter=0;
        string IP1;
        string kickUN;
        string kickIP;
        string[] ClientIPs = new string[100];
        int i = 0;

        static string connectionstring = @"Data Source=AMADEUS\MSSQLSERVER01;Initial Catalog=Users;Integrated Security=True";
        SqlConnection cnn = new SqlConnection(connectionstring);
        SimpleTcpServer server;

        public Server ()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        private void btnStart_Click(object sender, EventArgs e)  // Start Server Connection
        {
            server.Start();
            txtInfo.Text += $"Sever Started{Environment.NewLine}";
            btnStart.Enabled = false;
            btnSend.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            server = new SimpleTcpServer(txtIP.Text);
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;

        }
        private void Events_DataReceived(object sender, DataReceivedEventArgs e)   // Sever commands and Display Messages
        {
            this.Invoke((MethodInvoker)delegate
            {
                   
                txtInfo.Text += $" ({e.IpPort}) >>{Encoding.UTF8.GetString(e.Data)}{Environment.NewLine}";

                IP1 = e.IpPort.ToString();
                string query;
                SqlCommand cmd;

                for (int j = 0; j < i; j++)
                {
                    // Get Username and Message , and save IP into Database

                    index = Encoding.UTF8.GetString(e.Data).IndexOf(':');
                    username = Encoding.UTF8.GetString(e.Data).Substring(0, index);
                    msg = Encoding.UTF8.GetString(e.Data).Remove(0, index + 1);

                    query = "UPDATE UserInfo SET IP= @IP1  WHERE UserName='" + username + "' ";
                    cmd = new SqlCommand(query, cnn);

                    cmd.Parameters.AddWithValue("@IP1", IP1);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                    if (e.IpPort != ClientIPs[j])
                    {
                        if (msg.StartsWith(" @#$kick"))  // Select user to kick
                        {

                            kickUN = msg.Remove(0, 8);
                        
                            string query2 = "Select IP from UserInfo Where UserName='" + kickUN + "'";

                            cnn.Open();
                            cmd = new SqlCommand(query2, cnn);
                            kickIP = Convert.ToString(cmd.ExecuteScalar());
                            cnn.Close();

                            server.Send(kickIP, "Kicked");
                        }

                        else
                        {
                            server.Send(ClientIPs[j].ToString(), username);
                            server.Send(ClientIPs[j].ToString(), msg);

                            if (msg == " Kicked")
                            {
                                try
                                {
                                    if (isClientIP.SelectedItem != null)
                                    {

                                        server.DisconnectClient(isClientIP.SelectedItem.ToString());
                                    }
                                }

                                catch (FormatException x)
                                {
                                    MessageBox.Show(x.Message);
                                }
                            }
                        }

                    }

                    if (j == 99)
                    {
                        break;
                    }
                }

            });
        }

        private void Events_ClientDisconnected(object sender, ClientDisconnectedEventArgs e)  //Display Disconnected User
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"{e.IpPort} disconnected.{Environment.NewLine}";
                isClientIP.Items.Remove(e.IpPort);
            });
   
        }

        private void Events_ClientConnected(object sender, ClientConnectedEventArgs e)  //Display Connected User
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $" {e.IpPort} >> connected.{Environment.NewLine}";
                isClientIP.Items.Add(e.IpPort);
                ClientIPs[i]= e.IpPort;
                btnKick.Enabled = true;
            });
            userCounter++;
            i++;
        }

        private void btnSend_Click(object sender, EventArgs e)   // Send Message and commands to clients
        {
            if(server.IsListening)
            {
                if(!string.IsNullOrEmpty(txtMessage.Text)) 
                {
                    for (int j = 0; j < i; j++)
                    {
                        
                        username = "Server";
                        msg =(" "+txtMessage.Text);

                        server.Send(ClientIPs[j].ToString(), username);
                        server.Send(ClientIPs[j].ToString(), msg);

                        if (j==99)
                        {
                            break;
                        }
                    }

                    txtInfo.Text += $"Server: {txtMessage.Text}{Environment.NewLine}";
                    txtMessage.Text = string.Empty;
                }
            }
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        { 
                if (e.KeyCode == Keys.Enter)
                {
                    btnSend.PerformClick();
                }
        }


        private void btnData_Click(object sender, EventArgs e)  // Open Database
        {
            Database x = new Database();
            x.Show();
        }

        private void btnKick_Click(object sender, EventArgs e)  //Kick User
        {
            server.Send(isClientIP.SelectedItem.ToString(),"Kicked");

            userCounter--;

            if (userCounter == 0)
                btnKick.Enabled = false;

        }

        private void pictureBox1_Click(object sender, EventArgs e)  // Close Sever
        {
            for (int j = 0; j < i; j++)
            {
                server.Send(ClientIPs[j].ToString(), "ServerDisconnect");
                if (j == 99)
                {
                    break;
                }
            }
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)  //Minimize
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
