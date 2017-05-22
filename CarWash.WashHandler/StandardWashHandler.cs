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

        /// <summary>
        /// Initializes the Standard Wash Handler
        /// </summary>
        public StandardWashHandler()
        {
            this.WashProgram = new StandardCarWash();
            this.dbcontext = new CarWashContext();
        }

        /// <summary>
        /// Prepares and starts a backgroundworker to handle the standard car wash
        /// </summary>
        /// <param name="machineID">ID of the machine</param>
        /// <param name="progressCts">The Cancellation token source of the progress bar used to show progress of the wash</param>
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

        /// <summary>
        /// Cancels the current running wash
        /// </summary>
        public override void Cancel()
        {
            bw.CancelAsync();
        }
    }
}
