using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarWash.WashHandler;
using CarWash.Models;
using CarWash.Enum;

namespace CarWash
{
    public partial class TabTemplate : UserControl
    {
        public int machineID { get; set; }

        public TabTemplate()
        {
            InitializeComponent();
        }

        int selectedWash;
        Handler washHandler;

        private void TabTemplate_Load(object sender, EventArgs e)
        {
            txtInfoWash.Visible = true;
            selectedWash = 1;
            StandardInfo();
            washHandler = new Handler();
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
            lblCurrentStatus.Text = txtInfoWash.Text = "Standard wash contains Rinse, Wash, Drying";
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
                txtInfoWash.Text = "Silver wash wash contains Rinse, Soaking, Wash, Drying";
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
                txtInfoWash.Text = "Gold wash wash contains Rinse, Soaking, Wash, Underbody, Wax, Drying";
            }
        }

        private void btnCancelWash_Click(object sender, EventArgs e)
        {
            ///Cancel wash
            washHandler.CancelWash(machineID);

            //Text for label
            lblCurrentStatus.Text = "Stops wash!";
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
            lblCurrentStatus.Text = "Wash started!";
            lblCurrentProcess.Visible = true;
            lblCurrentProcess.Text = "";

            //Hides radiobuttons and Start
            btnCancelWash.Enabled = true;
            btnStartWash.Enabled = false;
            rdbtnStandardWash.Enabled = false;
            rdbtnSilverWash.Enabled = false;
            rdbtnGoldWash.Enabled = false;

            washHandler.StartWash(machineID, selectedWash, new Progress<WashProgress>(DisplayProgress));
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

            if (progress.OverallProgress != 100 && progress.WashProcess == null)
            {
                ProgramCancelled();
            }

        }

        private void ProgramCancelled()
        {
            lblCurrentStatus.Text = "Wash stopped!";
            lblCurrentProcess.Text = "";

            //Shows radiobuttons and Start
            btnStartWash.Enabled = true;
            rdbtnStandardWash.Enabled = true;
            rdbtnSilverWash.Enabled = true;
            rdbtnGoldWash.Enabled = true;
        }


        private void ProgressFinished()
        {
            lblCurrentStatus.Text = "Wash done!";
            lblCurrentProcess.Text = "";

            //Shows radiobuttons and Start
            btnStartWash.Enabled = true;
            btnCancelWash.Enabled = false;
            rdbtnStandardWash.Enabled = true;
            rdbtnSilverWash.Enabled = true;
            rdbtnGoldWash.Enabled = true;

            washHandler.WashFinished(machineID);
        }
    }
}
