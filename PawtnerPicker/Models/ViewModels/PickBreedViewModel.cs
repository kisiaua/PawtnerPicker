using System.ComponentModel.DataAnnotations;
using PawtnerPicker.Models.Validation;

namespace PawtnerPicker.Models.ViewModels;

public class PickBreedViewModel
{
    public int Popularity { get; set; }
    [MinMaxValidation("MinHeight", "MaxHeight", ErrorMessage = "Minimum height must be less than maximum height.")]
    public float MinHeight { get; set; }
    [MinMaxValidation("MinHeight", "MaxHeight", ErrorMessage = "Maximum height must be greater than minimum height.")]
    public float MaxHeight { get; set; }
    [MinMaxValidation("MinWeight", "MaxWeight", ErrorMessage = "Minimum weight must be less than maximum weight.")]
    public float MinWeight { get; set; }
    [MinMaxValidation("MinWeight", "MaxWeight", ErrorMessage = "Maximum weight must be greater than minimum weight.")]
    public float MaxWeight { get; set; }
    [MinMaxValidation("MinExpectancy", "MaxExpectancy", ErrorMessage = "Minimum life expectancy must be less than maximum life expectancy.")]
    public int MinExpectancy { get; set; }
    [MinMaxValidation("MinExpectancy", "MaxExpectancy", ErrorMessage = "Maximum life expectancy must be greater than minimum life expectancy.")]
    public int MaxExpectancy { get; set; }
    public float GroomingFrequencyValue { get; set; }
    public float SheddingValue { get; set; }
    public float EnergyLevelValue { get; set; }
    public float TrainabilityValue { get; set; }
    public float DemeanorValue { get; set; }
}