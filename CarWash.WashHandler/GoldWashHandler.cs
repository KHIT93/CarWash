using CarWash.Models;
using CarWash.Models.Programs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CarWash.WashHandler
{
    class GoldWashHandler : BaseWashHandler
    {
        CancellationTokenSource cts;

        /// <summary>
        /// Initializes the Silver Wash Handler
        /// </summary>
        public GoldWashHandler()
        {
            this.WashProgram = new GoldCarWash();
            cts = new CancellationTokenSource();
        }

        /// <summary>
        /// Starts the Gold carwash program as a task
        /// </summary>
        /// <param name="machineID">ID of the machine</param>
        /// <param name="progressObserver">The progressobserver used to update the progressbar></param>
        /// <returns>Returns the task used to run the program</returns>
        public async Task WashCarGold(int machineID, IProgress<WashProgress> progressObserver)
        {
            await this.RunWashASync(progressObserver);
            await this.SetWashAsFinishedAsync(this.washID);
        }

        /// <summary>
        /// Runs the tasks async
        /// </summary>
        /// <param name="progressObserver">The progressobserver used to update the progressbar></param>
        /// <returns>Returns the task used to run the program</returns>
        private Task RunWashASync(IProgress<WashProgress> progressObserver)
        {
            CancellationToken ct = cts.Token;
            return Task.Run(() =>
            {
                GoldCarWash wash = (GoldCarWash)this.WashProgram;
                this.CreateStatistics(this.WashProgram.GetType().Name);
                wash.Execute(ct, progressObserver);
            });
        }

        /// <summary>
        /// Cancels the currently running program
        /// </summary>
        public override void Cancel()
        {
            cts.Cancel();
            if (this.WashProgram.Running)
            {
                this.SetWashAsCancelled(this.washID);
            }
        }

        private Task SetWashAsFinishedAsync(Guid WashID)
        {
            return Task.Run(() => this.SetWashAsFinished(WashID));
        }
    }
}
