using System;
using System.Collections.Generic;
using CarWash.Models.Processes;

namespace CarWash.Models.Programs
{
    public class GoldCarWash : BaseCarWash
    {
        public GoldCarWash()
        {
			//Add Processes specific to this Car Wash Program
			this.Processes = new List<Interfaces.ICarWashProcess>()
			{
				new RinseProcess(),
				new SoakingProcess(),
				new WashProcess(),
                new UnderbodyWashProcess(),
                new WaxProcess(),
				new DryingProcess()
			};
        }
    }
}
