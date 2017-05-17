using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarWash
{
    public interface IWashHandler
    {
        Task WashCar(int machineID);
        Task WashCar(int machineID, CancellationToken ct);
        Task WashCar(int machineID, CancellationToken ct, IProgress<string> progress);
    }
    class WashHandler : IWashHandler
    {
        public Task WashCar(int machineID)
        {
            return WashCar(machineID, CancellationToken.None);
        }

        public Task WashCar(int machineID, CancellationToken ct)
        {
            return WashCar(machineID, ct, new Progress<string>());
        }

        public Task WashCar(int machineID, CancellationToken ct, IProgress<string> progress)
        {
            return Task.Run(() => 
            {

            });
        }
    }
}
