using System;
using System.Threading;
using System.Threading.Tasks;
using CarWash.Models.Programs;

namespace CarWash
{
    public interface IBaseWashHandler
    {
        Task WashCarBase(int machineID);
        Task WashCarBase(int machineID, CancellationToken ct);
        Task WashCarBase(int machineID, CancellationToken ct, IProgress<BaseCarWash> progress);
    }
    class BaseWashHandler : IBaseWashHandler
    {

        public Task WashCarBase(int machineID)
        {
            return WashCarBase(machineID, CancellationToken.None);
        }

        public Task WashCarBase(int machineID, CancellationToken ct)
        {
            return WashCarBase(machineID, ct, new Progress<BaseCarWash>());
        }

        public Task WashCarBase(int machineID, CancellationToken ct, IProgress<BaseCarWash> progress)
        {
            return Task.Run(() =>
            {

            });
        }
    }
}
