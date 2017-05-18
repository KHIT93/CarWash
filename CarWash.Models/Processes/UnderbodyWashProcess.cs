using System;
namespace CarWash.Models.Processes
{
    public class UnderbodyWashProcess : BaseProcess
    {
        public UnderbodyWashProcess()
        {
            this.Name = "Underbody Wash";
            this.TimeToRun = 6000;
        }
    }
}
