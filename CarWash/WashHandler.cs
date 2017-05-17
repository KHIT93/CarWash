using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarWash.Models.Programs;

namespace CarWash
{
    public interface IWashHandler
    {
        Task WashCarBase(int machineID);
        Task WashCarBase(int machineID, CancellationToken ct);
        Task WashCarBase(int machineID, CancellationToken ct, IProgress<BaseCarWash> progress);

        Task WashCarStandard(int machineID);
        Task WashCarStandard(int machineID, CancellationToken ct);
        Task WashCarStandard(int machineID, CancellationToken ct, IProgress<StandardCarWash> progress);
    }
    class WashHandler : IWashHandler
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
