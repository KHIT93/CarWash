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
        public GoldWashHandler()
        {
            this.WashProgram = new GoldCarWash();
            cts = new CancellationTokenSource();
        }

        public Task WashCarGold(int machineID, CancellationTokenSource progressBarCts)
        {
            return WashCarGold(machineID, progressBarCts, new Progress<GoldCarWash>());
        }

        public async Task WashCarGold(int machineID, CancellationTokenSource progressBarCts, IProgress<GoldCarWash> progress)
        {
            await RunWash(progressBarCts);
        }

        private Task RunWash(CancellationTokenSource progressBarCts)
        {
            CancellationToken ct = cts.Token;
            return Task.Run(() =>
            {
                GoldCarWash wash = (GoldCarWash)this.WashProgram;
                wash.Execute(ct, progressBarCts);
            });
        }

        public override void Cancel()
        {
            cts.Cancel();
        }
    }
}
