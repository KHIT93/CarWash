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
            this.Processes = new List<ICarWashProcess>()
            {
                new RinseProcess(),
                new WashProcess(),
                new DryingProcess()
            };
        }

        public void Execute(BackgroundWorker bw)
        {
            this.Running = true;
            bw.ReportProgress(this.Status());
            foreach (ICarWashProcess process in this.Processes)
            {
                if (bw.CancellationPending && !this.Cancelled)
                {
                    this.Cancel();
                }

                if (!this.Cancelled)
                {
                    bw.ReportProgress(this.Status());
                }

                process.Execute();

                if (!this.Cancelled)
                {
                    bw.ReportProgress(this.Status());
                }
            }
            this.Running = false;
        }
    }
}
