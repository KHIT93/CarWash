using System;
using System.Threading;
using System.Threading.Tasks;
using CarWash.Models.Programs;
using CarWash.Models;

namespace CarWash.WashHandler
{
    class SilverWashHandler : BaseWashHandler
    {
        CancellationTokenSource cts;

        public SilverWashHandler()
        {
            this.WashProgram = new SilverCarWash();
            this.cts = new CancellationTokenSource();
        }

        public Task WashCarSilver(int machineID, CancellationTokenSource progressBarCts)
        {
            return WashCarSilver(machineID, progressBarCts, new Progress<SilverCarWash>());
        }

        public Task WashCarSilver(int machineID, CancellationTokenSource progressBarCts, IProgress<SilverCarWash> progress)
        {
            CancellationToken ct = cts.Token;
            Task t = new Task(() => 
            {
                SilverCarWash wash = (SilverCarWash)this.WashProgram;
                wash.Execute(ct, progressBarCts);
                
            });

            t.Start();

            return t;
        }

        public override void Cancel()
        {
            cts.Cancel();
        }
    }
}
