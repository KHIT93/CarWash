using System;
namespace CarWash.Models.Processes
{
    public class SoakingProcess : BaseProcess
    {
        public SoakingProcess()
        {
            this.Name = "Soaking";
            this.TimeToRun = 12000;
        }
    }
}
