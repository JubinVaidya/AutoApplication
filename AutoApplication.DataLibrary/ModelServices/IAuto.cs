
using System.ComponentModel.DataAnnotations;

namespace AutoApplication.DataLibrary.ModelServices
{
    public interface IAuto
    {
        int AutoID { get; set; }
        string AutoModelName { get; set; }
        string AutoMakerName { get; set; }
        string AutoModelYear { get; set; }
        string AutoUsageStatus { get; set; }
        double AutoListedPrice { get; set; }
        string AutoVinNumber { get; set; }
        bool AutoInStock { get; set; }
        double AutoMilesTravelled { get; set; }
        string AutoInStockString { get; set; }
        string AutoImagePath { get; set; }
    }
}
