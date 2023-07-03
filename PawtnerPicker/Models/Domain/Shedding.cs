using System.ComponentModel.DataAnnotations;

namespace PawtnerPicker.Models.Domain;

public class Shedding
{
    [Key]
    public float SheddingValue { get; set; }
    public string? SheddingCategory { get; set; }
    
    // public ICollection<Breed> Breeds { get; set; }
}