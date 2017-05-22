using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CarWash.Models.Database;
using CarWash.Models.DataModels;

namespace CarWash.Communication
{
    public static class Statistics
    {
        public static List<Statistic> GetData()
        {
            List<Statistic> stats = new List<Statistic>();
            using (var context = new CarWashContext())
            {
                foreach (var stat in context.Statistics)
                {
                    stats.Add(stat);
                }
            }
            return stats;
        }

    }
}
