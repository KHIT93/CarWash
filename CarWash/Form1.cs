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
                tp.Text = "Vask " + i;
                tt.machineID = i;
                tp.Controls.Add(tt);

                tabControl1.Controls.Add(tp);
            }


        }

        //private void tcCarWash_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(rdbtnStandardWash);
        //    tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(rdbtnSilverWash);
        //    tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(rdbtnGoldWash);
        //    tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(txtInfoWash);
        //    tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(btnStartWash);
        //    tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(btnSendStatistic);
        //    tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(btnCancelWash);
        //    tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(lblCurrentStatus);
        //    tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(progBarWash);
        //    tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(lblCurrentProcess);

        //}
    }
}
