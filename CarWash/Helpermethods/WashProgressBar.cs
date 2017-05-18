using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static CarWash.Form1;

namespace CarWash.Helpermethods
{
    class WashProgressBar
    {
        public Task StartWashProgBar(CancellationToken ct, IProgress<WashProgress> progressObserver)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    progressObserver.Report(new WashProgress { OverallProgress = i });
                    Thread.Sleep(250);
                }
            });
        }
    }
}
