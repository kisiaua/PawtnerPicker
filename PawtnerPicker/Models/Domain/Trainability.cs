using System.ComponentModel.DataAnnotations;

namespace PawtnerPicker.Models.Domain;

public class Trainability
{
    [Key]
    public float TrainabilityValue { get; set; }
    public string? TrainabilityCategory { get; set; }
    
    // public ICollection<Breed> Breeds { get; set; }
}