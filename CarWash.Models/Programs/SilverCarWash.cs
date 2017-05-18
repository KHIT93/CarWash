using System;
using System.Collections.Generic;
using CarWash.Models.Processes;

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
    }
}
