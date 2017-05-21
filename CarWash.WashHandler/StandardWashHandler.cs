using CarWash.Models.Programs;
using System.ComponentModel;
using CarWash.Models;
using System.Threading;

namespace CarWash
{
    class StandardWashHandler : BaseWashHandler
    {
        BackgroundWorker bw;

        public StandardWashHandler()
        {
            this.WashProgram = new StandardCarWash();
        }

        public void WashCarStandard(int machineID, CancellationTokenSource progressCts)
        {
            bw = new BackgroundWorker();
            
            bw.WorkerSupportsCancellation = true;

            bw.DoWork += WashCarStandard_DoWork;
            bw.RunWorkerAsync(progressCts);
        }

        private void WashCarStandard_DoWork(object sender, DoWorkEventArgs e)
        {
            StandardCarWash wash = (StandardCarWash)this.WashProgram;
            wash.Execute(bw, (CancellationTokenSource)e.Argument);
        }

        public override void Cancel()
        {
            bw.CancelAsync();
        }
    }
}
