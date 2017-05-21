using System;
using System.Collections.Generic;
using CarWash.Models.Processes;
using CarWash.Models.Interfaces;
using System.Threading;
using System.ComponentModel;

namespace CarWash.Models.Programs
{
    public class StandardCarWash : BaseCarWash
    {
        public StandardCarWash()
        {
            //Add Processes specific to this Car Wash Program
            this.Processes = new List<Interfaces.ICarWashProcess>()
            {
                new RinseProcess(),
                new WashProcess(),
                new DryingProcess()
            };
        }

        public void Execute(BackgroundWorker bw, CancellationTokenSource progressBarCts)
        {
            this.Running = true;
            foreach (ICarWashProcess process in this.Processes)
            {
                if (bw.CancellationPending && !this.Cancelled)
                {
                    this.Cancel();
                    progressBarCts.Cancel();
                }
                process.Execute();
            }
            this.Running = false;
        }
    }
}
