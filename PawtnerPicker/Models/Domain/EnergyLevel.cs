using System.ComponentModel.DataAnnotations;

namespace PawtnerPicker.Models.Domain;

public class EnergyLevel
{
    [Key]
    public float EnergyLevelValue { get; set; }
    public string? EnergyLevelCategory { get; set; }
    
    // public ICollection<Breed> Breeds { get; set; }
}