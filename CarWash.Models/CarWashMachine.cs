using System;
using CarWash.Models.Interfaces;

namespace CarWash.Models
{
    public class CarWashMachine : ICarWashMachine
    {
        public CarWashMachine(int ID)
        {
            this._id = ID;
        }
        protected int _id;
        protected ICarWashHandler _washHandler;
        
        /// <summary>
        /// Gets or sets the <see cref="T:CarWash.Models.Interfaces.ICarWashHandler"/> instance that should be executed.
        /// </summary>
        /// <value>The <see cref="T:CarWash.Models.Interfaces.ICarWashHandler"/> instance.</value>
        public ICarWashHandler WashHandler
        {
            get
            {
                return this._washHandler;
            }
            set
            {
                if (this.IsAvailable() || value == null)
                {
                    this._washHandler = value;
                }
                else
                {
                    throw new Exception
                    (
                        $"We cannot process more than one program at a time. Please wait until we are finished. The current progress is {this._washHandler.WashProgram.Status()}"
                    );
                }
            }
        }

        /// <summary>
        /// Cancel the current <see cref="T:CarWash.Models.Interfaces.ICarWashProgram"/> execution.
        /// </summary>
        public void Cancel()
        {
            this._washHandler.WashProgram.Cancel();
            this._washHandler = null;
        }
        /// <summary>
        /// Execute the assigned <see cref="T:CarWash.Models.Interfaces.ICarWashProgram"/> instance.
        /// </summary>
        public void Execute()
        {
            this._washHandler.WashProgram.Execute();
            this._washHandler = null;
        }
        /// <summary>
        /// Determines if the <see cref="T:CarWash.Models.Interfaces.ICarWashMachine"/> instance is available to set a new job.
        /// </summary>
        /// <returns><c>true</c>, if the machine is available to start a new program, <c>false</c> otherwise.</returns>
        public bool IsAvailable()
        {
            return this._washHandler == null;
        }

        /// <summary>
        /// Gets the ID of the currently running instance.
        /// </summary>
        public int Id()
        {
            return this._id;
        }
    }
}
