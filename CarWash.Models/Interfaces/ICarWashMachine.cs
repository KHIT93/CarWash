using System;
namespace CarWash.Models.Interfaces
{
    public interface ICarWashMachine
    {
		/// <summary>
		/// Gets or sets the <see cref="T:CarWash.Models.Interfaces.ICarWashProgram"/> instance that should be executed.
		/// </summary>
		/// <value>The <see cref="T:CarWash.Models.Interfaces.ICarWashProgram"/> instance.</value>
		ICarWashProgram Program { get; set; }
		/// <summary>
		/// Determines if the <see cref="T:CarWash.Models.Interfaces.ICarWashMachine"/> instance is available to set a new job.
		/// </summary>
		/// <returns><c>true</c>, if available was ised, <c>false</c> otherwise.</returns>
		bool IsAvailable();
		/// <summary>
		/// Cancel the current <see cref="T:CarWash.Models.Interfaces.ICarWashProgram"/> execution.
		/// </summary>
		void Cancel();
		/// <summary>
		/// Execute the assigned <see cref="T:CarWash.Models.Interfaces.ICarWashProgram"/> instance.
		/// </summary>
		void Execute();
    }
}
