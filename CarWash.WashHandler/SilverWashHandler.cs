using System;
using System.Threading;
using System.Threading.Tasks;
using CarWash.Models.Programs;

namespace CarWash.WashHandler
{
    public interface ISilverWashHandler
    {
        Task WashCarSilver(int machineID);
        Task WashCarSilver(int machineID, CancellationToken ct);
        Task WashCarSilver(int machineID, CancellationToken ct, IProgress<SilverCarWash> progress);
    }
    class SilverWashHandler : ISilverWashHandler
    {
        public SilverCarWash carWash { get; set; }

        public SilverWashHandler()
        {
            carWash = new SilverCarWash();
        }

        public Task WashCarSilver(int machineID)
        {
            return WashCarSilver(machineID, CancellationToken.None);
        }

        public Task WashCarSilver(int machineID, CancellationToken ct)
        {
            return WashCarSilver(machineID, ct, new Progress<SilverCarWash>());
        }

        public Task WashCarSilver(int machineID, CancellationToken ct, IProgress<SilverCarWash> progress)
        {
            carWash = new SilverCarWash();
            Task t = new Task(() => 
            {
                carWash.Execute();
                
            });

            t.Start();

            return t;
        }

        public bool GetStatus()
        {
            return carWash.Running;
        }
    }
}
