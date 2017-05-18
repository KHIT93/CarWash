using System;
namespace CarWash.Models.Processes
{
    public class DryingProcess : BaseProcess
    {
        public DryingProcess()
        {
            this.Name = "Drying";
            this.TimeToRun = 6000;
        }
    }
}
