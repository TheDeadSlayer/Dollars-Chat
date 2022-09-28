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
using System.Media;
using System.Drawing.Drawing2D;

namespace Dollars_Chat
{
    public partial class Chat : Form
    {
        static string connectionstring = @"Data Source=AMADEUS\MSSQLSERVER01;Initial Catalog=Users;Integrated Security=True";
        SqlConnection cnn = new SqlConnection(connectionstring);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]   // Rounded Edges
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        //Move Application With Mouse

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
        string TempUserName;
        string TempMsg = null;
        string TempType;
        string TempUN;
        int vipType = 0;

        Global_UI_Class bbl_Old = new Global_UI_Class();
        SimpleTcpClient client;
        SoundPlayer splay = new SoundPlayer("..\\..\\Music\\DRRR_OP.wav"); // Music Reference Location
        SoundPlayer splay1 = new SoundPlayer("..\\..\\Music\\Killer_Queen.wav"); // Music Reference Location

        public Chat()
        {
            if (!this.DesignMode)
            {
                InitializeComponent();

                this.FormBorderStyle = FormBorderStyle.None;
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            }

            bbl_Old.Top = 0 - bbl_Old.Height + 10;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient("172.20.13.33", 9000);
            client.Events.DataReceived += Events_DataReceived;
            btnSend.Enabled = false;

            try                                                     //Connect to Server
            {
                client.Connect();
                lblConnected.Visible = Enabled;
                client.Send(Login.username + ": " + "Connected");
                btnSend.Enabled = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Login.Type == "vip")
            {
                ChooseVip.Enabled = true;
                btnPlayMusic.Enabled = true;
                pictureBox4.Enabled = true;
                lblvipUI.Enabled = true;

                btnPlayMusic.Visible = true;
                ChooseVip.Visible = true;
                pictureBox4.Visible = true;
                lblvipUI.Visible = true;
            }

            if (Login.Type == "admin")
            {
                btnPlayMusic.Enabled = true;
                pictureBox4.Enabled = true;
                lblKick.Enabled = true;
                txtKick.Enabled = true;
                btnKick.Enabled = true;

                btnPlayMusic.Visible = true;
                pictureBox4.Visible = true;
                lblKick.Visible = true;
                txtKick.Visible = true;
                btnKick.Visible = true;
            }

            if (client.IsConnected)
            {
                if (Login.Type == "normal")
                {
                    lblConnected.ForeColor = System.Drawing.Color.White;
                    lblConnected.Text = "Connected as >> " + Login.username;
                }

                if (Login.Type == "vip")
                {
                    lblConnected.ForeColor = System.Drawing.Color.Red;
                    lblConnected.Text = "Connected as >> " + Login.username;
                }

                if (Login.Type == "admin")
                {
                    lblConnected.ForeColor = System.Drawing.Color.Purple;
                    lblConnected.Text = "Connected as >> " + Login.username;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)         // Send Message
        {
            if (client.IsConnected)
            {
                if (!string.IsNullOrEmpty(txtMessage.Text))
                {

                    if (Login.Type == "normal")
                    {
                        client.Send(Login.username + ": " + txtMessage.Text);
                        addMessageNormal(txtMessage.Text);
                    }
                    else if (Login.Type == "vip")
                    {

                        if (ChooseVip.SelectedItem.ToString() == "Red")
                        {
                            client.Send("1" + Login.username + ": " + txtMessage.Text);
                            addMessageVIP1(txtMessage.Text);
                        }
                        else if (ChooseVip.SelectedItem.ToString() == "Red (Kanji)")
                        {
                            client.Send("2" + Login.username + ": " + txtMessage.Text);
                            addMessageVIP2(txtMessage.Text);
                        }
                        else if (ChooseVip.SelectedItem.ToString() == "Yellow")
                        {
                            client.Send("3" + Login.username + ": " + txtMessage.Text);
                            addMessageVIP3(txtMessage.Text);
                        }
                        else if (ChooseVip.SelectedItem.ToString() == "Yellow (Kanji)")
                        {
                            client.Send("4" + Login.username + ": " + txtMessage.Text);
                            addMessageVIP4(txtMessage.Text);
                        }
                        else if (ChooseVip.SelectedItem.ToString() == "Green")
                        {
                            client.Send("5" + Login.username + ": " + txtMessage.Text);
                            addMessageVIP5(txtMessage.Text);
                        }
                        else if (ChooseVip.SelectedItem.ToString() == "Green (Kanji)")
                        {
                            client.Send("6" + Login.username + ": " + txtMessage.Text);
                            addMessageVIP6(txtMessage.Text);
                        }
                        else if (ChooseVip.SelectedItem.ToString() == "Pink")
                        {
                            client.Send("7" + Login.username + ": " + txtMessage.Text);
                            addMessageVIP7(txtMessage.Text);
                        }
                        else if (ChooseVip.SelectedItem.ToString() == "Black")
                        {
                            client.Send("8" + Login.username + ": " + txtMessage.Text);
                            addMessageVIP8(txtMessage.Text);
                        }
                    }
                    else if (Login.Type == "admin")
                    {
                        client.Send(Login.username + ": " + txtMessage.Text);
                        addMessageAdmin(txtMessage.Text);
                    }

                    txtMessage.Text = string.Empty;
                }
            }
        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)   // Recieve Messages and Display UI Accordingly 
        {
            this.Invoke((MethodInvoker)delegate
            {

                if (Encoding.UTF8.GetString(e.Data).StartsWith(" "))
                {
                    TempMsg = Encoding.UTF8.GetString(e.Data).TrimStart(' ');
                }
                else if (Encoding.UTF8.GetString(e.Data).StartsWith("Kicked"))
                {
                    MessageBox.Show("Kicked");
                    client.Send(Login.username + ": " + "Kicked");
                    client.Disconnect();
                    splay.Stop();
                    Login x = new Login();
                    this.Hide();
                    x.Show();

                }
                else if (Encoding.UTF8.GetString(e.Data).StartsWith("ServerDisconnect"))
                {
                    addMessageServerOFF();
                }
                else if (Encoding.UTF8.GetString(e.Data).StartsWith("1"))
                {
                    TempUserName = Encoding.UTF8.GetString(e.Data).TrimStart('1');
                    vipType = 1;
                }
                else if (Encoding.UTF8.GetString(e.Data).StartsWith("2"))
                {
                    TempUserName = Encoding.UTF8.GetString(e.Data).TrimStart('2');
                    vipType = 2;
                }
                else if (Encoding.UTF8.GetString(e.Data).StartsWith("3"))
                {
                    TempUserName = Encoding.UTF8.GetString(e.Data).TrimStart('3');
                    vipType = 3;
                }
                else if (Encoding.UTF8.GetString(e.Data).StartsWith("4"))
                {
                    TempUserName = Encoding.UTF8.GetString(e.Data).TrimStart('4');
                    vipType = 4;
                }
                else if (Encoding.UTF8.GetString(e.Data).StartsWith("5"))
                {
                    TempUserName = Encoding.UTF8.GetString(e.Data).TrimStart('5');
                    vipType = 5;
                }
                else if (Encoding.UTF8.GetString(e.Data).StartsWith("6"))
                {
                    TempUserName = Encoding.UTF8.GetString(e.Data).TrimStart('6');
                    vipType = 6;
                }
                else if (Encoding.UTF8.GetString(e.Data).StartsWith("7"))
                {
                    TempUserName = Encoding.UTF8.GetString(e.Data).TrimStart('7');
                    vipType = 7;
                }
                else if (Encoding.UTF8.GetString(e.Data).StartsWith("8"))
                {
                    TempUserName = Encoding.UTF8.GetString(e.Data).TrimStart('8');
                    vipType = 8;
                }

                else
                {
                    TempUserName = Encoding.UTF8.GetString(e.Data);
                }

                if (!String.IsNullOrEmpty(TempMsg))
                {
                    // Search for type according to user name

                    string query3 = "Select Type from UserInfo Where UserName='" + TempUserName + "'";

                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query3, cnn);
                    TempType = Convert.ToString(cmd.ExecuteScalar());
                    cnn.Close();

                    TempUN = Login.username;
                    Login.username = TempUserName;

                    if (TempType == "vip" && vipType == 1 && (TempMsg != "Connected") && (TempMsg != "Disconnected"))
                        addMessageVIP1(TempMsg);
                    if (TempType == "vip" && vipType == 2 && (TempMsg != "Connected") && (TempMsg != "Disconnected"))
                        addMessageVIP2(TempMsg);
                    if (TempType == "vip" && vipType == 3 && (TempMsg != "Connected") && (TempMsg != "Disconnected"))
                        addMessageVIP3(TempMsg);
                    if (TempType == "vip" && vipType == 4 && (TempMsg != "Connected") && (TempMsg != "Disconnected"))
                        addMessageVIP4(TempMsg);
                    if (TempType == "vip" && vipType == 5 && (TempMsg != "Connected") && (TempMsg != "Disconnected"))
                        addMessageVIP5(TempMsg);
                    if (TempType == "vip" && vipType == 6 && (TempMsg != "Connected") && (TempMsg != "Disconnected"))
                        addMessageVIP6(TempMsg);
                    if (TempType == "vip" && vipType == 7 && (TempMsg != "Connected") && (TempMsg != "Disconnected"))
                        addMessageVIP7(TempMsg);
                    if (TempType == "vip" && vipType == 8 && (TempMsg != "Connected") && (TempMsg != "Disconnected"))
                        addMessageVIP8(TempMsg);

                    else if (TempMsg == "Connected")
                    {
                        addMessageConnected();
                    }

                    else if (TempMsg == "Disconnected")
                    {
                        addMessageDisconnected();
                    }

                    else if (TempMsg == "Kicked")
                    {
                        addMessageKicked();
                    }

                    else if (TempType == "normal")
                    {
                        addMessageNormal(TempMsg);
                    }

                    else if (TempType == "admin")
                    {
                        addMessageAdmin(TempMsg);
                    }

                    if (TempUserName == "Server")
                    {
                        addMessageFounder(TempMsg);
                    }

                    Login.username = TempUN;
                }

                TempMsg = null;
            });
        }


        public void addMessageNormal(string message)                   //Normal User UI
        {
            ChatBubble1 bbl = new Dollars_Chat.ChatBubble1(message);

            if (bbl_Old is Connected_UI|| bbl_Old is Disconnected_UI || bbl_Old is Kicked_UI || bbl_Old is ServerDisconnect_UI)
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom -75;
            }
            else
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom + 10;
            }
    
            panel1.Controls.Add(bbl);
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            bbl.BringToFront();
            bbl_Old = bbl;
        }

        public void addMessageVIP1(string message)                   //Red VIP User UI      
        {
            VIPUserChatUI_1 bbl = new Dollars_Chat.VIPUserChatUI_1(message);

            if (bbl_Old is Connected_UI || bbl_Old is Disconnected_UI || bbl_Old is Kicked_UI || bbl_Old is ServerDisconnect_UI)
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom -75;
            }

            else
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom + 10;
            }

            panel1.Controls.Add(bbl);
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            bbl.BringToFront();
            bbl_Old = bbl;
        }

        public void addMessageVIP2(string message)                   //Red(Kanji) VIP User UI  
        {
            VIPUserChatUI_2 bbl = new Dollars_Chat.VIPUserChatUI_2(message);

            if (bbl_Old is Connected_UI || bbl_Old is Disconnected_UI || bbl_Old is Kicked_UI || bbl_Old is ServerDisconnect_UI)
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom -75;
            }
            else
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom + 10;
            }

            panel1.Controls.Add(bbl);
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            bbl.BringToFront();
            bbl_Old = bbl;
        }

        public void addMessageVIP3(string message)                   //Yellow VIP User UI  
        {
            VIPUserChatUI_3 bbl = new Dollars_Chat.VIPUserChatUI_3(message);

            if (bbl_Old is Connected_UI || bbl_Old is Disconnected_UI || bbl_Old is Kicked_UI || bbl_Old is ServerDisconnect_UI)
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom -75;
            }
            else
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom + 10;
            }

            panel1.Controls.Add(bbl);
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            bbl.BringToFront();
            bbl_Old = bbl;
        }

        public void addMessageVIP4(string message)                   //Yellow(Kanji) VIP User UI  
        {
            VIPUserChatUI_4 bbl = new Dollars_Chat.VIPUserChatUI_4(message);

            if (bbl_Old is Connected_UI || bbl_Old is Disconnected_UI || bbl_Old is Kicked_UI || bbl_Old is ServerDisconnect_UI)
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom -75;
            }
            else
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom + 10;
            }

            panel1.Controls.Add(bbl);
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            bbl.BringToFront();
            bbl_Old = bbl;
        }

        public void addMessageVIP5(string message)                   //Green VIP User UI  
        {
            VIPUserChatUI_5 bbl = new Dollars_Chat.VIPUserChatUI_5(message);

            if (bbl_Old is Connected_UI || bbl_Old is Disconnected_UI || bbl_Old is Kicked_UI || bbl_Old is ServerDisconnect_UI)
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom -75;
            }
            else
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom + 10;
            }

            panel1.Controls.Add(bbl);
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            bbl.BringToFront();
            bbl_Old = bbl;
        }

        public void addMessageVIP6(string message)                   //Green(Kanji) VIP User UI  
        {
            VIPUserChatUI_6 bbl = new Dollars_Chat.VIPUserChatUI_6(message);

            if (bbl_Old is Connected_UI || bbl_Old is Disconnected_UI || bbl_Old is Kicked_UI || bbl_Old is ServerDisconnect_UI)
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom -75;
            }
            else
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom + 10;
            }

            panel1.Controls.Add(bbl);
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            bbl.BringToFront();
            bbl_Old = bbl;
        }

        public void addMessageVIP7(string message)                   //Pink VIP User UI  
        {
            VIPUserChatUI_7 bbl = new Dollars_Chat.VIPUserChatUI_7(message);

            if (bbl_Old is Connected_UI || bbl_Old is Disconnected_UI || bbl_Old is Kicked_UI || bbl_Old is ServerDisconnect_UI)
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom -75;
            }
            else
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom + 10;
            }

            panel1.Controls.Add(bbl);
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            bbl.BringToFront();
            bbl_Old = bbl;
        }

        public void addMessageVIP8(string message)                   //Black VIP User UI  
        {
            VIPUserChatUI_8 bbl = new Dollars_Chat.VIPUserChatUI_8(message);

            if (bbl_Old is Connected_UI || bbl_Old is Disconnected_UI || bbl_Old is Kicked_UI || bbl_Old is ServerDisconnect_UI)
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom -75;
            }
            else
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom + 10;
            }

            panel1.Controls.Add(bbl);
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            bbl.BringToFront();
            bbl_Old = bbl;
        }

        public void addMessageAdmin(string message)                   //Admin User UI  
        {
            AdminUserChatUI bbl = new Dollars_Chat.AdminUserChatUI(message);

            if (bbl_Old is Connected_UI || bbl_Old is Disconnected_UI || bbl_Old is Kicked_UI || bbl_Old is ServerDisconnect_UI)
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom -75;
            }
            else
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom + 10;
            }

            panel1.Controls.Add(bbl);
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            bbl.BringToFront();
            bbl_Old = bbl;
        }

        public void addMessageFounder(string message)                   //Server Message UI  
        {
            FounderChatUI bbl = new Dollars_Chat.FounderChatUI(message);

            if (bbl_Old is Connected_UI || bbl_Old is Disconnected_UI || bbl_Old is Kicked_UI || bbl_Old is ServerDisconnect_UI)
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom -75;
            }
            else
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom + 10;
            }

            panel1.Controls.Add(bbl);
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            bbl.BringToFront();
            bbl_Old = bbl;
        }

        public void addMessageConnected()                   //User Connected UI  
        {
            Connected_UI bbl = new Dollars_Chat.Connected_UI();

            if (bbl_Old is Connected_UI || bbl_Old is Disconnected_UI || bbl_Old is Kicked_UI || bbl_Old is ServerDisconnect_UI)
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom -75;
            }
            else
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom + 10;
            }

            panel1.Controls.Add(bbl);
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            bbl.BringToFront();
            bbl_Old = bbl;
        }

        public void addMessageDisconnected()                   //User Disconnected UI
        {
            Disconnected_UI bbl = new Dollars_Chat.Disconnected_UI();

            if (bbl_Old is Connected_UI || bbl_Old is Disconnected_UI || bbl_Old is Kicked_UI || bbl_Old is ServerDisconnect_UI)
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom -75;
            }
            else
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom + 10;
            }

            panel1.Controls.Add(bbl);
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            bbl.BringToFront();
            bbl_Old = bbl;
        }

        public void addMessageKicked()                   //User Kicked UI
        {
            Kicked_UI bbl = new Dollars_Chat.Kicked_UI();

            if (bbl_Old is Connected_UI || bbl_Old is Disconnected_UI||bbl_Old is Kicked_UI || bbl_Old is ServerDisconnect_UI)
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom - 75;
            }
            else
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom + 10;
            }

            panel1.Controls.Add(bbl);
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            bbl.BringToFront();
            bbl_Old = bbl;
        }

        public void addMessageServerOFF()                   //Server Closed UI
        {
            ServerDisconnect_UI bbl = new Dollars_Chat.ServerDisconnect_UI();

            if (bbl_Old is Connected_UI || bbl_Old is Disconnected_UI || bbl_Old is Kicked_UI||bbl_Old is ServerDisconnect_UI)
                {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom - 75;
            }
            else
            {
                bbl.Location = chatBubble11.Location;
                bbl.Size = chatBubble11.Size;
                bbl.Anchor = chatBubble11.Anchor;
                bbl.Top = bbl_Old.Bottom + 10;
            }

            panel1.Controls.Add(bbl);
            panel1.VerticalScroll.Value = panel1.VerticalScroll.Maximum;
            bbl.BringToFront();
            bbl_Old = bbl;
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)    //Press Enter to Send
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnSend.PerformClick();
            }
        }

        private void YourComboBox_KeyPress(object sender, KeyPressEventArgs e)     // ComboBox
        {
            e.Handled = true;
        }

        private void btnPlayMusic_Click(object sender, EventArgs e)          // Play Music
        {
            
            splay.PlayLooping();

        }

        private void pictureBox2_Click(object sender, EventArgs e)         // Back to Login
        {
            if (client.IsConnected)
            {
                client.Send(Login.username + ": " + "Disconnected");
                client.Disconnect();
            }
            splay.Stop();
            Login x = new Login();
            this.Close();
            x.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)      // Close Application
        {
            if (client.IsConnected)
            {
                client.Send(Login.username + ": " + "Disconnected");
            }
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)    // Stop Music
        {
            splay.Stop();
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)  // Hover ToolTip
        {
            toolTip1.Show("Stop Music", pictureBox4);
        }

        private void btnKick_Click(object sender, EventArgs e)        // Kick User
        {
            if (client.IsConnected)
            {
                client.Send(Login.username + ": " + "@#$kick" + txtKick.Text);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)    // Show Drip
        {
            Drip x = new Drip(this);
            x.Show();
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)   // Hidden Pixel
        {
            pictureBox5.Visible = true;
            splay1.Play();
            pictureBox6.Enabled = false;
        }

        public void InvisPic()                                         //Hiden Pixel Hide
        {
            pictureBox5.Visible = false;
            pictureBox6.Enabled = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)    //Minimize
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtKick_KeyDown(object sender, KeyEventArgs e)   //Press Enter to kick
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnKick.PerformClick();
            }
        }

    }

}
