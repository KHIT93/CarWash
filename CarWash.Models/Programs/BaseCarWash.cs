using System;
using System.Collections.Generic;
using CarWash.Models.Interfaces;
namespace CarWash.Models.Programs
{
    public class BaseCarWash : ICarWashProgram
    {
        public BaseCarWash()
        {
        }

        public bool Running { get; set; }
        public bool Cancelled { get; set; }
        public List<ICarWashProcess> Processes { get; set; }
        public string Name { get; set; }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
