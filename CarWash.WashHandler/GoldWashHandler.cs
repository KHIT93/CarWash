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
        /// <param name="progressBarCts">The Cancellation token source of the progress bar used to show progress of the wash</param>
        /// <returns>Returns the task used to run the program</returns>
        public async Task WashCarGold(int machineID, CancellationTokenSource progressBarCts)
        {
            await RunWashASync(progressBarCts);
        }

        /// <summary>
        /// Runs the tasks async
        /// </summary>
        /// <param name="progressBarCts">The Cancellation token source of the progress bar used to show progress of the wash</param>
        /// <returns>Returns the task used to run the program</returns>
        private Task RunWashASync(CancellationTokenSource progressBarCts)
        {
            CancellationToken ct = cts.Token;
            return Task.Run(() =>
            {
                GoldCarWash wash = (GoldCarWash)this.WashProgram;
                wash.Execute(ct, progressBarCts);
            });
        }

        /// <summary>
        /// Cancels the currently running program
        /// </summary>
        public override void Cancel()
        {
            cts.Cancel();
        }
    }
}
