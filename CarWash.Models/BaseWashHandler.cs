using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Models.Interfaces;

namespace CarWash.Models
{
    public abstract class BaseWashHandler : ICarWashHandler
    {
        public int MachineID { get; set; }
        public ICarWashProgram WashProgram { get; set; }

        public abstract void Cancel();
    }
}
