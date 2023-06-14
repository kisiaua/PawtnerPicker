namespace PawtnerPicker.Models.ViewModels;

public class PickBreedViewModel
{
    public int Popularity { get; set; }
    public float MinHeight { get; set; }
    public float MaxHeight { get; set; }
    public float MinWeight { get; set; }
    public float MaxWeight { get; set; }
    public int MinExpectancy { get; set; }
    public int MaxExpectancy { get; set; }
    public float GroomingFrequency { get; set; }
    public float Shedding { get; set; }
    public float EnergyLevel { get; set; }
    public float Trainability { get; set; }
    public float Demeanor { get; set; }
}