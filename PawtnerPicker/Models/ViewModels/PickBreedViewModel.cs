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
    public float GroomingFrequencyValue { get; set; }
    public float SheddingValue { get; set; }
    public float EnergyLevelValue { get; set; }
    public float TrainabilityValue { get; set; }
    public float DemeanorValue { get; set; }
}