using System;
namespace CarWash.Models.Interfaces
{
    public interface ICarWashProcess
    {
        bool Finished { get; set; }
        bool Cancelled { get; set; }
        bool Skipped { get; set; }
        int TimeToRun { get; set; }
        string Name { get; set; }
        void Execute();
        void Skip();
        void Cancel();
    }
}
