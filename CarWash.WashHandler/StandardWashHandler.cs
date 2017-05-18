using System;
using System.Threading;
using System.Threading.Tasks;
using CarWash.Models.Programs;
using System.ComponentModel;

namespace CarWash
{
    public interface IStandardWashHandler
    {
        void WashCarStandard(int machineID);
    }
    class StandardWashHandler : IStandardWashHandler
    {
        BackgroundWorker bw;

        public void WashCarStandard(int machineID)
        {
            bw = new BackgroundWorker();

            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;

            bw.DoWork += WashCarStandard_DoWork;
            bw.ProgressChanged += WashCarStandard_ProgressChanged;
            bw.RunWorkerCompleted += WashCarStandard_RunWorkerCompleted;

        }

        private void WashCarStandard_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void WashCarStandard_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void WashCarStandard_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        public void CancelWashCarStandard(int machineID)
        {

        }
    }
}
