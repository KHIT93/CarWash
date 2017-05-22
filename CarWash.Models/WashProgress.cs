using CarWash.Models.Interfaces;

namespace CarWash.Models
{
    public class WashProgress
    {
        public int OverallProgress { get; set; }
        public ICarWashProcess WashProcess { get; set; }
    }
}
