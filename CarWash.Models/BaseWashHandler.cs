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
        /// <summary>
        /// ID of the machine
        /// </summary>
        public int MachineID { get; set; }
        protected Guid washID;

        /// <summary>
        /// The current running wash program
        /// </summary>
        public ICarWashProgram WashProgram { get; set; }

        /// <summary>
        /// Function used to cancel the running program
        /// </summary>
        public abstract void Cancel();
    }
}
