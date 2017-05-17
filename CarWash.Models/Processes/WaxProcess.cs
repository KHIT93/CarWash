using System;
namespace CarWash.Models.Processes
{
    public class WaxProcess : BaseProcess
    {
        public WaxProcess()
        {
            this.Name = "Wax";
            this.TimeToRun = 30;
        }
    }
}
