using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWash.Models.DataModels
{
    public class Statistic
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		public int MachineID { get; set; }
        public string Program { get; set; }
		public bool Running { get; set; }
		public bool Cancelled { get; set; }
		public bool Finished { get; set; }
	}
}
