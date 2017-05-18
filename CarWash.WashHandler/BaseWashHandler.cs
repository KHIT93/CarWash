using System;
using System.Threading;
using System.Threading.Tasks;
using CarWash.Models.Programs;
using System.ComponentModel;

namespace CarWash
{
    public interface IBaseWashHandler
    {
        void WashCarBase(int machineID);
    }
    class BaseWashHandler : IBaseWashHandler
    {
        BackgroundWorker bw;

        public void WashCarBase(int machineID)
        {
            bw = new BackgroundWorker();

            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;

            bw.DoWork += WashCarBase_DoWork;
            bw.ProgressChanged += WashCarBase_ProgressChanged;
            bw.RunWorkerCompleted += WashCarBase_RunWorkerCompleted;

        }

        private void WashCarBase_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void WashCarBase_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void WashCarBase_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        public void CancelWashCarBase(int machineID)
        {

        }
    }
}
