using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
		/// <summary>
		/// Execute the car wash program.
		/// </summary>
		public virtual void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
