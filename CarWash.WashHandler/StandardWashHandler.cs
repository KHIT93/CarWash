using CarWash.Models.Programs;
using System.ComponentModel;
using CarWash.Models;
using System.Threading;
using CarWash.Models.Database;
using CarWash.Models.DataModels;
using System;
using System.Data.Entity.Core;

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
            bw.RunWorkerCompleted += WashCarStandard_Finished;
            bw.RunWorkerAsync(progressCts);
        }

        private void WashCarStandard_DoWork(object sender, DoWorkEventArgs e)
        {
            StandardCarWash wash = (StandardCarWash)this.WashProgram;
            this.CreateStatistics(this.WashProgram.GetType().Name);
            wash.Execute(bw, (CancellationTokenSource)e.Argument);
        }

        /// <summary>
        /// Runs when the worker has finished and handles persistance of statistics to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WashCarStandard_Finished(object sender, RunWorkerCompletedEventArgs e)
        {
            this.SetWashAsFinished(this.washID);
        }

        /// <summary>
        /// Cancels the current running wash
        /// </summary>
        public override void Cancel()
        {
            bw.CancelAsync();
            this.SetWashAsCancelled(this.washID);
        }
    }
}
