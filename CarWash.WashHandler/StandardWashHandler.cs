using CarWash.Models.Programs;
using System.ComponentModel;
using CarWash.Models;
using System.Threading;

namespace CarWash
{
    class StandardWashHandler : BaseWashHandler
    {
        BackgroundWorker bw;

        /// <summary>
        /// Initializes the Standard Wash Handler
        /// </summary>
        public StandardWashHandler()
        {
            this.WashProgram = new StandardCarWash();
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
