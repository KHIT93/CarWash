using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarWash.WashHandler;
using CarWash.Enum;
using CarWash.Models;

namespace CarWash
{
    public partial class Form1 : Form
    {
        int selectedWash;
        Handler washHandler;

        public Form1()
        {
            InitializeComponent();
            washHandler = new Handler();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtInfoWash.Visible = true;
            selectedWash = 1;
            StandardInfo();
        }

        private void rdbtnStandardWash_CheckedChanged(object sender, EventArgs e)
        {
            //Enable start and cancel buttons
            btnStartWash.Enabled = true;
            btnCancelWash.Enabled = true;

            //Saves the selected washtype
            if (rdbtnStandardWash.Checked)
            {
                selectedWash = (int)WashTypes.Standard;
                StandardInfo();
            }
        }

        public void StandardInfo()
        {
            //Sets info for standard wash
            txtInfoWash.Visible = true;
            lblCurrentStatus.Text = txtInfoWash.Text = "Standardvask informationer";
        }

        private void rdbtnSilverWash_CheckedChanged(object sender, EventArgs e)
        {
            //Enable start and cancel buttons
            btnStartWash.Enabled = true;
            btnCancelWash.Enabled = true;

            //Sets info for the specific wash, saves the selected washtype
            if (rdbtnSilverWash.Checked)
            {
                selectedWash = (int)WashTypes.Silver;
                txtInfoWash.Visible = true;
                txtInfoWash.Text = "Sølvvask informationer";
            }
        }

        private void rdbtnGoldWash_CheckedChanged(object sender, EventArgs e)
        {
            //Enable start and cancel buttons
            btnStartWash.Enabled = true;
            btnCancelWash.Enabled = true;

            //Sets info for the specific wash, saves the selected washtype
            if (rdbtnGoldWash.Checked)
            {
                selectedWash = (int)WashTypes.Gold;
                txtInfoWash.Visible = true;
                txtInfoWash.Text = "Guldvask informationer";
            }
        }

        private void btnCancelWash_Click(object sender, EventArgs e)
        {
            ///Cancel wash
            washHandler.CancelWash(1);

            //Text for label
            lblCurrentStatus.Text = "Stopper vask!";

            //Shows radiobuttons and Start
            btnStartWash.Enabled = true;
            rdbtnStandardWash.Enabled = true;
            rdbtnSilverWash.Enabled = true;
            rdbtnGoldWash.Enabled = true;
        }

        private void btnSendStatistic_Click(object sender, EventArgs e)
        {
            ///Statistics of the wash
            LoginForm lf = new LoginForm();

            lf.ShowDialog();
        }

        private void btnStartWash_Click(object sender, EventArgs e)
        {
            progBarWash.Value = 0;

            //Shows Labal, and give it a predetermined text
            lblCurrentStatus.Visible = true;
            lblCurrentStatus.Text = "Vask igang!";
            lblCurrentProcess.Visible = true;
            lblCurrentProcess.Text = "";

            //Hides radiobuttons and Start
            btnCancelWash.Enabled = true;
            btnStartWash.Enabled = false;
            rdbtnStandardWash.Enabled = false;
            rdbtnSilverWash.Enabled = false;
            rdbtnGoldWash.Enabled = false;

            washHandler.StartWash(1, selectedWash, new Progress<WashProgress>(DisplayProgress));
        }

        private void DisplayProgress(WashProgress progress)
        {
            //Updates the progressbar in UI
            progBarWash.Value = progress.OverallProgress;
            if (progress.WashProcess != null)
            {
                lblCurrentProcess.Text = progress.WashProcess.Name;
            }

            if (progress.OverallProgress == 100)
            {
                ProgressFinished();
            }
            
        }

        private void ProgressFinished()
        {
            lblCurrentStatus.Text = "Vask færdig!";
            lblCurrentProcess.Text = "";

            //Shows radiobuttons and Start
            btnStartWash.Enabled = true;
            btnCancelWash.Enabled = false;
            rdbtnStandardWash.Enabled = true;
            rdbtnSilverWash.Enabled = true;
            rdbtnGoldWash.Enabled = true;
        }

        private void tcCarWash_SelectedIndexChanged(object sender, EventArgs e)
        {
            tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(rdbtnStandardWash);
            tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(rdbtnSilverWash);
            tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(rdbtnGoldWash);
            tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(txtInfoWash);
            tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(btnStartWash);
            tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(btnSendStatistic);
            tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(btnCancelWash);
            tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(lblCurrentStatus);
            tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(progBarWash);
            tcCarWash.TabPages[tcCarWash.SelectedIndex].Controls.Add(lblCurrentProcess);

        }
    }
}
