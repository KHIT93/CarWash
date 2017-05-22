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
            using (var context = new CarWashContext())
            {
                Statistic stats = new Statistic { MachineID = this.MachineID, Program = this.WashProgram.GetType().Name, Running = true, Cancelled = false, Finished = false };
                context.Statistics.Add(stats);
                context.SaveChanges();
                this.washID = stats.Id;
            }
            wash.Execute(bw, (CancellationTokenSource)e.Argument);
        }

        /// <summary>
        /// Runs when the worker has finished and handles persistance of statistics to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WashCarStandard_Finished(object sender, RunWorkerCompletedEventArgs e)
        {
            using (var context = new CarWashContext())
            {
                Statistic stats = context.Statistics.Find(this.washID);
                stats.Running = false;
                stats.Finished = true;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Cancels the current running wash
        /// </summary>
        public override void Cancel()
        {
            bw.CancelAsync();
            using (var context = new CarWashContext())
            {
                Statistic stats = context.Statistics.Find(this.washID);
                stats.Running = false;
                stats.Cancelled = true;
                context.SaveChanges();
            }
        }
    }
}
