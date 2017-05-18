using System;
namespace CarWash.Models.Processes
{
    public class WashProcess : BaseProcess
    {
        public WashProcess()
        {
            this.Name = "Washing";
            this.TimeToRun = 18000;
        }
    }
}
