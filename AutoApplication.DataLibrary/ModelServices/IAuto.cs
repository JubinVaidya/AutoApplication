
using System.ComponentModel.DataAnnotations;

namespace AutoApplication.DataLibrary.ModelServices
{
    public interface IAuto
    {
        [Display(Name = "Auto ID")]
        [Range(0, 20, ErrorMessage = "Please enter valid integer Number")]
        int AutoID { get; set; }
        string AutoModelName { get; set; }
        string AutoMakerName { get; set; }
        string AutoModelYear { get; set; }
        string AutoUsageStatus { get; set; }
        double AutoListedPrice { get; set; }
        string AutoVinNumber { get; set; }
        bool AutoInStock { get; set; }
        double AutoMilesTravelled { get; set; }
    }
}
