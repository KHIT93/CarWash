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
        IProgress<WashProgress> progressObserver;
        StandardCarWash wash;

        /// <summary>
        /// Initializes the Standard Wash Handler
        /// </summary>
        public StandardWashHandler(IProgress<WashProgress> progressObserver)
        {
            this.WashProgram = new StandardCarWash();
            this.progressObserver = progressObserver;
        }

        /// <summary>
        /// Prepares and starts a backgroundworker to handle the standard car wash
        /// </summary>
        /// <param name="machineID">ID of the machine</param>
        public void WashCarStandard(int machineID)
        {
            bw = new BackgroundWorker();
            
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;

            bw.DoWork += WashCarStandard_DoWork;
            bw.ProgressChanged += WashCarStandard_ProgressChanged;

            bw.RunWorkerCompleted += WashCarStandard_Finished;
            bw.RunWorkerAsync();
        }

        private void WashCarStandard_DoWork(object sender, DoWorkEventArgs e)
        {
            wash = (StandardCarWash)this.WashProgram;
            this.CreateStatistics(this.WashProgram.GetType().Name);
            wash.Execute(bw);
        }

        private void WashCarStandard_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressObserver.Report(new WashProgress { OverallProgress = e.ProgressPercentage, WashProcess = wash.Processes.Find(process => process.Running == true) } );
            
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
