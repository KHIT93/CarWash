using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash
{
    public partial class Form1 : Form
    {
        int selectedWash;
        CancellationTokenSource tcs;

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

            tcs.Cancel();

            lblCurrentStatus.Visible = false;

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
            ///Start af vask

            //Progressbar
            tcs = new CancellationTokenSource();
            CancellationToken ct = tcs.Token;

            Task progBar = StartWashProgBar(ct ,new Progress<ImportProgress>(DisplayProgress));

            //Får overført valgt radiobutton
            int SelectedWash = selectedWash;

            //Sætter labal synlig, og giver den en forudbestemt tekst
            lblCurrentStatus.Visible = true;
            lblCurrentStatus.Text = "Vask igang!";

            btnStartWash.Enabled = false;
            rdbtnStandardWash.Enabled = false;
            rdbtnSilverWash.Enabled = false;
            rdbtnGoldWash.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnStartWash.Enabled = false;
            btnCancelWash.Enabled = false;
        }

        public Task StartWashProgBar(CancellationToken ct ,IProgress<ImportProgress> progressObserver)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    progressObserver.Report(new ImportProgress { OverallProgress = i });
                    Thread.Sleep(250);
                }
            });
        }

        public class ImportProgress
        {
            public int OverallProgress { get; set; }
        }

        private void DisplayProgress(ImportProgress progress)
        {
            progBarWash.Value = progress.OverallProgress;
        }
    }
}
