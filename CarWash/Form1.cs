using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash
{
    public partial class Form1 : Form
    {
        int selectedWash;

        enum WashType
        {
            Standard = 1,
            Silver = 2,
            Gold = 3
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void rdbtnStandardWash_CheckedChanged(object sender, EventArgs e)
        {
            btnStartWash.Enabled = true;
            btnCancelWash.Enabled = true;
            if (rdbtnStandardWash.Checked)
            {
                selectedWash = (int)WashType.Standard;
                txtInfoWash.Visible = true;
                txtInfoWash.Text = "Standardvask informationer";
            }
        }

        private void rdbtnSilverWash_CheckedChanged(object sender, EventArgs e)
        {
            btnStartWash.Enabled = true;
            btnCancelWash.Enabled = true;
            if (rdbtnSilverWash.Checked)
            {
                selectedWash = (int)WashType.Silver;
                txtInfoWash.Visible = true;
                txtInfoWash.Text = "Sølvvask informationer";
            }
        }

        private void rdbtnGoldWash_CheckedChanged(object sender, EventArgs e)
        {
            btnStartWash.Enabled = true;
            btnCancelWash.Enabled = true;
            if (rdbtnGoldWash.Checked)
            {
                selectedWash = (int)WashType.Gold;
                txtInfoWash.Visible = true;
                txtInfoWash.Text = "Guldvask informationer";
            }
        }

        private void btnCancelWash_Click(object sender, EventArgs e)
        {
            //Anullering af vask

            btnStartWash.Enabled = true;
            rdbtnStandardWash.Enabled = true;
            rdbtnSilverWash.Enabled = true;
            rdbtnGoldWash.Enabled = true;
        }

        private void btnSendStatistic_Click(object sender, EventArgs e)
        {
            //Statistik af vasken, så kontoret kan lave rapport
        }

        private void btnStartWash_Click(object sender, EventArgs e)
        {
            //Start af vask

            int SelectedWash = selectedWash;

            btnStartWash.Enabled = false;
            rdbtnStandardWash.Enabled = false;
            rdbtnSilverWash.Enabled = false;
            rdbtnGoldWash.Enabled = false;

            WashHandler.SilverWashHandler swh = new WashHandler.SilverWashHandler();
            swh.WashCarSilver(1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnStartWash.Enabled = false;
            btnCancelWash.Enabled = false;
        }
    }
}
