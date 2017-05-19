using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CarWash.Models.Interfaces;
namespace CarWash.Models.Programs
{
    /// <summary>
    /// Base car wash program.
    /// </summary>
    public abstract class BaseCarWash : ICarWashProgram
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CarWash.Models.Programs.BaseCarWash"/> is running.
        /// </summary>
        /// <value><c>true</c> if running; otherwise, <c>false</c>.</value>
        public bool Running { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CarWash.Models.Programs.BaseCarWash"/> is cancelled.
        /// </summary>
        /// <value><c>true</c> if cancelled; otherwise, <c>false</c>.</value>
        public bool Cancelled { get; set; }
		/// <summary>
		/// Gets or sets the <see cref="T:CarWash.Models.Interfaces.ICarWashProcess"/> instances that are used with this car wash program.
		/// </summary>
		/// <value>The processes.</value>
		public List<ICarWashProcess> Processes { get; set; }
		/// <summary>
		/// Execute the car wash program.
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Cancel this running program and any processes that are currently running.
		/// </summary>
		public virtual void Cancel()
        {
            //Loop through all processes and cancel anything that is currently running
            this.Processes.ForEach(CancelProcess);
			Task.Delay(100);
			this.Cancelled = true;
            this.Running = false;
        }
		/// <summary>
		/// Execute the car wash program.
		/// </summary>
		public virtual void Execute()
        {
            this.Running = true;
            foreach (ICarWashProcess process in this.Processes)
            {
                process.Execute();
            }
            this.Running = false;
        }
		/// <summary>
		/// Status for how far this instance is with the processing.
		/// </summary>
		/// <returns>The status.</returns>
        public virtual int Status()
        {
            int completedProcesses = this.Processes.FindAll(p => p.Finished == true).Count;
            if(completedProcesses != 0)
            {
                int singleProcessPercentage = 100 / this.Processes.FindAll(p => p.Finished == true).Count;
                return singleProcessPercentage;
            }
            return 0;
        }
        /// <summary>
        /// Cancels a process.
        /// </summary>
        /// <param name="process">Process.</param>
        protected virtual void CancelProcess(ICarWashProcess process)
        {
            process.Cancel();
        }
    }
}
