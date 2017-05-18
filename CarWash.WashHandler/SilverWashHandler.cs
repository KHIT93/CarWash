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
    public class SilverWashHandler : ISilverWashHandler
    {
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
            Task t = new Task(() => 
            {
                SilverCarWash carWash = new SilverCarWash();
                carWash.Execute();
            });

            t.Start();

            t.Wait();

            return t;
        }
        
    }
}
