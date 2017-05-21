using CarWash.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Models.Interfaces
{
    public interface ICarWashHandler
    {
        int MachineID { get; set; }

        ICarWashProgram WashProgram { get; set; }

        void Cancel();
    }
}
