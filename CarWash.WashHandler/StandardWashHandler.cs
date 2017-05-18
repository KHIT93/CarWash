using System;
using System.Threading;
using System.Threading.Tasks;
using CarWash.Models.Programs;

namespace CarWash.WashHandler
{
    public interface IStandardWashHandler
    {
        Task WashCarStandard(int machineID);
        Task WashCarStandard(int machineID, CancellationToken ct);
        Task WashCarStandard(int machineID, CancellationToken ct, IProgress<StandardCarWash> progress);
    }
    class StandardWashHandler : IStandardWashHandler
    {
        public Task WashCarStandard(int machineID)
        {
            return WashCarStandard(machineID, CancellationToken.None);
        }

        public Task WashCarStandard(int machineID, CancellationToken ct)
        {
            return WashCarStandard(machineID, ct, new Progress<StandardCarWash>());
        }

        public Task WashCarStandard(int machineID, CancellationToken ct, IProgress<StandardCarWash> progress)
        {
            return Task.Run(() =>
            {

            });
        }
    }
}
