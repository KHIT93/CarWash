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
        SilverCarWash carWash; 

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
            carWash.Execute();
            Console.WriteLine(GetStatus().ToString());
            Thread.Sleep(1000);
            Console.WriteLine(GetStatus().ToString());
            t.Wait();

            return t;
        }

        public bool GetStatus()
        {
            return carWash.Running;
        }
    }
}
