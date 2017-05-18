using CarWash.Models.Programs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CarWash.WashHandler
{
    public interface IGoldWashHandler
    {
        Task WashCarGold(int machineID);
        Task WashCarGold(int machineID, CancellationToken ct);
        Task WashCarGold(int machineID, CancellationToken ct, IProgress<GoldCarWash> progress);
    }
    class GoldWashHandler : IGoldWashHandler
    {
        public Task WashCarGold(int machineID)
        {
            return WashCarGold(machineID, CancellationToken.None);
        }

        public Task WashCarGold(int machineID, CancellationToken ct)
        {
            return WashCarGold(machineID, ct, new Progress<GoldCarWash>());
        }

        public async Task WashCarGold(int machineID, CancellationToken ct, IProgress<GoldCarWash> progress)
        {
            await RunWash();
        }

        private Task RunWash()
        {
            return Task.Run(() =>
            {

            });
        }
    }
}
