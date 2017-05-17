﻿using System;
using CarWash.Models.Interfaces;
namespace CarWash.Models.Processes
{
    public class BaseCarWashProcess : ICarWashProcess
    {
        public BaseCarWashProcess()
        {
        }

        public bool Finished { get; set; }
        public bool Cancelled { get; set; }
        public bool Skipped { get; set; }
        public int TimeToRun { get; set; }
        public string Name { get; set; }

        public virtual void Cancel()
        {
            throw new NotImplementedException();
        }

        public virtual void Execute()
        {
            throw new NotImplementedException();
        }

        public virtual void Skip()
        {
            throw new NotImplementedException();
        }
    }
}
