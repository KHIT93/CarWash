using System;
using System.Collections.Generic;
using CarWash.Models.Processes;

namespace CarWash.Models.Programs
{
    public class StandardCarWash : BaseCarWash
    {
        public StandardCarWash()
        {
            //Add Processes specific to this Car Wash Program
            this.Processes = new List<Interfaces.ICarWashProcess>()
            {
                new RinseProcess(),
                new WashProcess(),
                new DryingProcess()
            };
        }
    }
}
