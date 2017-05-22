using System;
using System.Threading;
using System.Threading.Tasks;
using CarWash.Models.Programs;
using CarWash.Models;
using CarWash.Models.Database;
using CarWash.Models.DataModels;

namespace CarWash.WashHandler
{
    class SilverWashHandler : BaseWashHandler
    {
        CancellationTokenSource cts;

        /// <summary>
        /// Initializes the Silver Wash Handler
        /// </summary>
        public SilverWashHandler()
        {
            this.WashProgram = new SilverCarWash();
            this.cts = new CancellationTokenSource();
        }

        /// <summary>
        /// Starts the silver carwash program as a task
        /// </summary>
        /// <param name="machineID">ID of the machine</param>
        /// <param name="progressObserver">The progressobserver used to update the progressbar></param>
        /// <returns>Returns the task used to run the program</returns>
        public Task WashCarSilver(int machineID, IProgress<WashProgress> progressObserver)
        {
            CancellationToken ct = cts.Token;
            Task t = new Task(() => 
            {
                SilverCarWash wash = (SilverCarWash)this.WashProgram;
                wash.Execute(ct, progressObserver);
                //this.CreateStatistics(this.WashProgram.GetType().Name);
            });

            t.Start();
            //Task finish = t.ContinueWith(wh => this.SetWashAsFinished(this.washID));
            //finish.Wait();

            return t;
        }

        /// <summary>
        /// Cancels the current running program
        /// </summary>
        public override void Cancel()
        {
            cts.Cancel();
            //this.SetWashAsCancelled(this.washID);
        }
    }
}
