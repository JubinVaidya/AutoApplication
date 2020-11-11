using AutoApplication.Services;

namespace AutoApplication.Models
{
    public class Auto : IAuto
    {

        public int AutoID { get; set; }
        public string AutoModelName { get; set; }
        public string AutoMakerName { get; set; }
        public string AutoModelYear { get; set; }
        public string AutoUsageStatus { get; set; }
        public double AutoListedPrice { get; set; }
        public string AutoVinNumber { get; set; }
    }
}