using System;
using System.Collections.Generic;
using CarWash.Models.Processes;
using System.Threading;
using CarWash.Models.Interfaces;

namespace CarWash.Models.Programs
{
    public class SilverCarWash : BaseCarWash
    {
        public SilverCarWash()
        {
			//Add Processes specific to this Car Wash Program
			this.Processes = new List<Interfaces.ICarWashProcess>()
			{
				new RinseProcess(),
                new SoakingProcess(),
				new WashProcess(),
				new DryingProcess()
			};
        }

        public void Execute(CancellationToken ct, IProgress<WashProgress> progressObserver)
        {
            this.Running = true;
            foreach (ICarWashProcess process in this.Processes)
            {
                if (ct.IsCancellationRequested && !this.Cancelled)
                {
                    this.Cancel();
                }

                if (!this.Cancelled)
                {
                    progressObserver.Report(new WashProgress { OverallProgress = this.Status(), WashProcess = process });
                }

                process.Execute();

                if (!this.Cancelled)
                {
                    progressObserver.Report(new WashProgress { OverallProgress = this.Status(), WashProcess = process });
                }
                else
                {
                    progressObserver.Report(new WashProgress { OverallProgress = this.Status(), WashProcess = null });
                }
            }
            this.Running = false;
        }
    }
}
