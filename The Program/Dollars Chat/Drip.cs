using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Dollars_Chat
{
    public partial class Drip : Form    // SOO MUCH DRIP
    {
        Chat x;

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

        private void Drip_Load(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        public Drip(Chat y) 
        {
            x = y;

            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        // Animate Form

        private int dx = 10;
        private int dy = 5;
        int a = Screen.PrimaryScreen.Bounds.Width - 441;
        int b = Screen.PrimaryScreen.Bounds.Height - 610;

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            if (true)
            {
                this.Location = new Point(this.Location.X + dx, this.Location.Y+dy);
                if (Location.X <=0 || Location.X >= a)
                {
                    dx = -dx;
                }
                else
                {
                    this.Invalidate();
                }

                if (Location.Y <=0 || Location.Y >= b)
                {
                    dy = -dy;
                }
                else
                {
                    this.Invalidate();
                }

            }
        }

      
        private void Drip_KeyDown(object sender, KeyEventArgs e)  // Press Esc to close
        {
            if (e.KeyCode==Keys.Escape)
            {
                x.InvisPic();
                this.Close();
            }
        }

    }
}
