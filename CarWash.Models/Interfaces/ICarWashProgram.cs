using System;
using System.Collections.Generic;

namespace CarWash.Models.Interfaces
{
    public interface ICarWashProgram
    {
        bool Running { get; set; }
        bool Cancelled { get; set; }
        string Name { get; set; }
        List<ICarWashProcess> Processes { get; set; }
        void Execute();
        void Cancel();
    }
}
