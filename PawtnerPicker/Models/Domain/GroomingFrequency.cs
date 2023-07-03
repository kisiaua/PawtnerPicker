using System.ComponentModel.DataAnnotations;

namespace PawtnerPicker.Models.Domain;

public class GroomingFrequency
{
    [Key]
    public float GroomingFrequencyValue { get; set; }
    public string? GroomingFrequencyCategory { get; set; }
}