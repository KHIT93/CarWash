using System;
using System.Collections.Generic;

namespace CarWash.Models.Interfaces
{
    /// <summary>
    /// Interface to implement a new car wash program.
    /// </summary>
    public interface ICarWashProgram
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CarWash.Models.Interfaces.ICarWashProgram"/> is running.
        /// </summary>
        /// <value><c>true</c> if running; otherwise, <c>false</c>.</value>
        bool Running { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CarWash.Models.Interfaces.ICarWashProgram"/> is cancelled.
        /// </summary>
        /// <value><c>true</c> if cancelled; otherwise, <c>false</c>.</value>
        bool Cancelled { get; set; }
        /// <summary>
        /// Gets or sets the readable name of this car wash program.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }
		/// <summary>
		/// Gets or sets the <see cref="T:CarWash.Models.Interfaces.ICarWashProcess"/> instances that are used with this car wash program.
		/// </summary>
		/// <value>The processes.</value>
		List<ICarWashProcess> Processes { get; set; }
        /// <summary>
        /// Execute the car wash program.
        /// </summary>
        void Execute();
        /// <summary>
        /// Cancel this running program and any processes that are currently running.
        /// </summary>
        void Cancel();
    }
}
