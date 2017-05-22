using System;
using System.Collections.Generic;
using CarWash.Models.Processes;
using System.Threading;
using CarWash.Models.Interfaces;

namespace CarWash.Models.Programs
{
    public class GoldCarWash : BaseCarWash
    {
        //CancellationToken ct;

        public GoldCarWash()
        {
            //Add Processes specific to this Car Wash Program
            this.Processes = new List<Interfaces.ICarWashProcess>()
            {
                new RinseProcess(),
                new SoakingProcess(),
                new WashProcess{ TimeToRun = 24000 },
                new UnderbodyWashProcess(),
                new WaxProcess(),
                new DryingProcess { TimeToRun = 18000 }
            };
        }

        public void Execute(CancellationToken ct, CancellationTokenSource progressBarCts)
        {
            this.Running = true;
            foreach (ICarWashProcess process in this.Processes)
            {
                process.Execute();
                if (ct.IsCancellationRequested && !this.Cancelled)
                {
                    this.Cancel();
                    progressBarCts.Cancel();
                }
            }
            this.Running = false;
        }
    }
}
