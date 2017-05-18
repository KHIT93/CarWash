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
        protected ICarWashProgram _program;
		/// <summary>
		/// Gets or sets the <see cref="T:CarWash.Models.Interfaces.ICarWashProgram"/> instance that should be executed.
		/// </summary>
		/// <value>The <see cref="T:CarWash.Models.Interfaces.ICarWashProgram"/> instance.</value>
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
		/// <summary>
		/// Cancel the current <see cref="T:CarWash.Models.Interfaces.ICarWashProgram"/> execution.
		/// </summary>
		public void Cancel()
        {
            this.Program.Cancel();
            this._program = null;
        }
		/// <summary>
		/// Execute the assigned <see cref="T:CarWash.Models.Interfaces.ICarWashProgram"/> instance.
		/// </summary>
		public void Execute()
        {
            this.Program.Execute();
            this._program = null;
        }
		/// <summary>
		/// Determines if the <see cref="T:CarWash.Models.Interfaces.ICarWashMachine"/> instance is available to set a new job.
		/// </summary>
		/// <returns><c>true</c>, if the machine is available to start a new program, <c>false</c> otherwise.</returns>
		public bool IsAvailable()
        {
            return this._program == null;
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
