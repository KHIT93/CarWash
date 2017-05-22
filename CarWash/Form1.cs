using System;
using System.Windows.Forms;

namespace CarWash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int i = 1; i < 6; i++)
            {
                TabPage tp = new TabPage();
                TabTemplate tt = new TabTemplate();
                tp.Width = this.tabControl1.Width;
                tp.Height = this.tabControl1.Height;

                tt.Visible = true;
                tt.Dock = DockStyle.Top;
                tt.Width = tp.Width;
                tt.Height = tp.Height;
                tp.Text = "Wash " + i;
                tt.machineID = i;
                tp.Controls.Add(tt);

                tabControl1.Controls.Add(tp);
            }


        }

        //}
    }
}
