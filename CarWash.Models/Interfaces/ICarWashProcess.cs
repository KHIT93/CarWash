using System;
namespace CarWash.Models.Interfaces
{
    /// <summary>
    /// Interface to implement a new process that can be used by an ICarWashProgram implementation
    /// </summary>
    public interface ICarWashProcess
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CarWash.Models.Interfaces.ICarWashProcess"/> is running.
        /// </summary>
        /// <value><c>true</c> if running; otherwise, <c>false</c>.</value>
        bool Running { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CarWash.Models.Interfaces.ICarWashProcess"/> is finished.
        /// </summary>
        /// <value><c>true</c> if finished; otherwise, <c>false</c>.</value>
        bool Finished { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CarWash.Models.Interfaces.ICarWashProcess"/> is cancelled.
        /// </summary>
        /// <value><c>true</c> if cancelled; otherwise, <c>false</c>.</value>
        bool Cancelled { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CarWash.Models.Interfaces.ICarWashProcess"/> is skipped.
        /// </summary>
        /// <value><c>true</c> if skipped; otherwise, <c>false</c>.</value>
        bool Skipped { get; set; }
        /// <summary>
        /// Gets or sets the time that this process needs to run.
        /// </summary>
        /// <value>The time to run.</value>
        int TimeToRun { get; set; }
        /// <summary>
        /// Gets or sets the readable name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }
        /// <summary>
        /// Execute the process
        /// </summary>
        void Execute();
        /// <summary>
        /// Skip this process.
        /// </summary>
        void Skip();
        /// <summary>
        /// Cancel this process. This defines when it is allowed to cancel the process.
        /// </summary>
        void Cancel();
    }
}
