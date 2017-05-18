using System;
namespace CarWash.Models.Processes
{
    public class RinseProcess : BaseProcess
    {
        public RinseProcess()
        {
            this.Name = "Rinsing";
            this.TimeToRun = 3000;
        }
    }
}
