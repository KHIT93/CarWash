﻿using System;
using System.Threading;
using CarWash.Models.Interfaces;
namespace CarWash.Models.Processes
{
    /// <summary>
    /// Base car wash process.
    /// </summary>
    public abstract class BaseProcess : ICarWashProcess
    {
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:CarWash.Models.Interfaces.ICarWashProcess"/> is finished.
		/// </summary>
		/// <value><c>true</c> if finished; otherwise, <c>false</c>.</value>
		public bool Finished { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:CarWash.Models.Interfaces.ICarWashProcess"/> is cancelled.
		/// </summary>
		/// <value><c>true</c> if cancelled; otherwise, <c>false</c>.</value>
		public bool Cancelled { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:CarWash.Models.Interfaces.ICarWashProcess"/> is skipped.
		/// </summary>
		/// <value><c>true</c> if skipped; otherwise, <c>false</c>.</value>
		public bool Skipped { get; set; }
		/// <summary>
		/// Gets or sets the time that this process needs to run.
		/// </summary>
		/// <value>The time to run.</value>
		public int TimeToRun { get; set; }
		/// <summary>
		/// Gets or sets the readable name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CarWash.Models.Processes.BaseProcess"/> is running.
        /// </summary>
        /// <value><c>true</c> if running; otherwise, <c>false</c>.</value>
        public bool Running { get; set; }

        /// <summary>
        /// Cancel this process. This defines when it is allowed to cancel the process.
        /// </summary>
        public virtual void Cancel()
        {
            this.Running = true;
            Thread.Sleep(200);
            this.Running = false;
            this.Finished = true;
        }
		/// <summary>
		/// Execute the process
		/// </summary>
		public virtual void Execute()
        {
            Thread.Sleep(this.TimeToRun);
        }
		/// <summary>
		/// Skip this process.
		/// </summary>
		public virtual void Skip()
        {
            this.Skipped = true;
            //Write on screen that this will be skipped
        }
    }
}
