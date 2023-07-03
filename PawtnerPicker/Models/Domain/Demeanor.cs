using System.ComponentModel.DataAnnotations;

namespace PawtnerPicker.Models.Domain;

public class Demeanor
{
    [Key]
    public float DemeanorValue { get; set; }
    public string? DemeanorCategory { get; set; }
    
    // public ICollection<Breed> Breeds { get; set; }
}