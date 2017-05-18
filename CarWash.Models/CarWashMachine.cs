using System;
using CarWash.Models.Interfaces;

namespace CarWash.Models
{
    public class CarWashMachine : ICarWashMachine
    {
        protected ICarWashProgram _program;
        public CarWashMachine()
        {
        }

        public ICarWashProgram Program
        {
            get
            {
                return this._program;
            }
            set
            {
                if(this.IsAvailable())
                {
                    this._program = value;
                }
                else
                {
					throw new Exception
					(
						$"We cannot process more than one program at a time. Please wait until we are finished. The current progress is {this.Program.Status()}"
					);
                }
            }
        }

        public void Cancel()
        {
            this.Program.Cancel();
            this._program = null;
        }

        public void Execute()
        {
            this.Program.Execute();
            this._program = null;
        }

        public bool IsAvailable()
        {
            return this._program == null;
        }
    }
}
