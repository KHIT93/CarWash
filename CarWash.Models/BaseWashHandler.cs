using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.Models.Interfaces;
using CarWash.Models.Database;
using CarWash.Models.DataModels;

namespace CarWash.Models
{
    public abstract class BaseWashHandler : ICarWashHandler
    {
        /// <summary>
        /// ID of the machine
        /// </summary>
        public int MachineID { get; set; }
        protected Guid washID;

        /// <summary>
        /// The current running wash program
        /// </summary>
        public ICarWashProgram WashProgram { get; set; }

        /// <summary>
        /// Function used to cancel the running program
        /// </summary>
        public abstract void Cancel();

        public virtual void CreateStatistics(string washProgram)
        {
            using (var context = new CarWashContext())
            {
                Statistic stats = new Statistic { MachineID = this.MachineID, Program = washProgram, Running = true, Cancelled = false, Finished = false };
                context.Statistics.Add(stats);
                context.SaveChanges();
                this.washID = stats.Id;
            }
        }

        public virtual void SetWashAsFinished(Guid WashID)
        {
            using (var context = new CarWashContext())
            {
                Statistic stats = context.Statistics.Find(WashID);
                stats.Running = false;
                stats.Finished = true;
                context.SaveChanges();
            }
        }

        public virtual void SetWashAsCancelled(Guid WashID)
        {
            using (var context = new CarWashContext())
            {
                Statistic stats = context.Statistics.Find(WashID);
                stats.Running = false;
                stats.Cancelled = true;
                context.SaveChanges();
            }
        }
    }
}
