using AutoApplication.Services;

namespace AutoApplication.Models
{
    public class Auto : IAuto
    {
        public int AutoID { get; set; }
        public string AutoModelName { get; set; }
        public string AutoMaker { get; set; }
        public string AutoModelYear { get; set; }
    }
}