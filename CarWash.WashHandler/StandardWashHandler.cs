using CarWash.Models.Programs;
using System.ComponentModel;
using CarWash.Models;
using System.Threading;
using CarWash.Models.Database;
using CarWash.Models.DataModels;
using System;

namespace CarWash
{
    class StandardWashHandler : BaseWashHandler
    {
        BackgroundWorker bw;
        private CarWashContext dbcontext;
        IProgress<WashProgress> progressObserver;
        StandardCarWash wash;

        /// <summary>
        /// Initializes the Standard Wash Handler
        /// </summary>
        public StandardWashHandler(IProgress<WashProgress> progressObserver)
        {
            this.WashProgram = new StandardCarWash();
            this.dbcontext = new CarWashContext();
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

            bw.RunWorkerAsync();
        }
        
        private void WashCarStandard_DoWork(object sender, DoWorkEventArgs e)
        {
            //this.dbcontext.Statistics.Add(new Statistic { MachineID = this.MachineID, Program = this.WashProgram.GetType().Name, Running = true, Cancelled = false, Finished = false });
            wash = (StandardCarWash)this.WashProgram;
            wash.Execute(bw);
        }

        private void WashCarStandard_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressObserver.Report(new WashProgress { OverallProgress = e.ProgressPercentage, WashProcess = wash.Processes.Find(process => process.Running == true) } );
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
