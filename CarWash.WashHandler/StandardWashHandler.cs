using CarWash.Models.Programs;
using System.ComponentModel;
using CarWash.Models;
using System.Threading;
using CarWash.Models.Database;
using CarWash.Models.DataModels;

namespace CarWash
{
    class StandardWashHandler : BaseWashHandler
    {
        BackgroundWorker bw;
        private CarWashContext dbcontext;

        public StandardWashHandler()
        {
            this.WashProgram = new StandardCarWash();
            this.dbcontext = new CarWashContext();
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
            //this.dbcontext.Statistics.Add(new Statistic { MachineID = this.MachineID, Program = this.WashProgram.GetType().Name, Running = true, Cancelled = false, Finished = false });
            StandardCarWash wash = (StandardCarWash)this.WashProgram;
            wash.Execute(bw, (CancellationTokenSource)e.Argument);
        }

        public override void Cancel()
        {
            bw.CancelAsync();
        }
    }
}
