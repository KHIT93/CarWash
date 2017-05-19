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
        public StandardCarWash carWash { get; set; }
        BackgroundWorker bw;

        public StandardWashHandler()
        {
            carWash = new StandardCarWash();
        }

        public void WashCarStandard(int machineID)
        {
            bw = new BackgroundWorker();
            
            bw.WorkerSupportsCancellation = true;

            bw.DoWork += WashCarStandard_DoWork;
            bw.RunWorkerCompleted += WashCarStandard_RunWorkerCompleted;
            bw.RunWorkerAsync();

        }

        private void WashCarStandard_DoWork(object sender, DoWorkEventArgs e)
        {
            carWash.Execute();
        }

        private void WashCarStandard_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        public void CancelWashCarStandard(int machineID)
        {

        }
    }
}
