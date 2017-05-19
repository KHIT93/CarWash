using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static CarWash.Form1;
using CarWash.WashHandler;

namespace CarWash.Helpermethods
{
    class WashProgressBar
    {
        public Task StartWashProgBar(int machineID, Handler washHandler, CancellationToken ct, IProgress<WashProgress> progressObserver)
        {
            return Task.Run(() =>
            {
                int progress = 0;
                do
                {
                    progress = washHandler.GetWashStatus(machineID);
                    ct.ThrowIfCancellationRequested();
                    progressObserver.Report(new WashProgress { OverallProgress = progress });
                    Thread.Sleep(250);
                } while (progress != 100);
                
            });
        }
    }
}
