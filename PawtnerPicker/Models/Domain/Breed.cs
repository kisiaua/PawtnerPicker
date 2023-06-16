namespace PawtnerPicker.Models.Domain;

public class Breed
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string? BreedName { get; set; }
    public string? Temperament { get; set; }
    public int Popularity { get; set; }
    public float MinHeight { get; set; }
    public float MaxHeight { get; set; }
    public float MinWeight { get; set; }
    public float MaxWeight { get; set; }
    public int MinExpectancy { get; set; }
    public int MaxExpectancy { get; set; }
    public string? Group { get; set; }
    public float GroomingFrequencyValue { get; set; }
    public string? GroomingFrequencyCategory { get; set; }
    public float SheddingValue { get; set; }
    public string? SheddingCategory { get; set; }
    public float EnergyLevelValue { get; set; }
    public string? EnergyLevelCategory { get; set; }
    public float TrainabilityValue { get; set; }
    public string? TrainabilityCategory { get; set; }
    public float DemeanorValue { get; set; }
    public string? DemeanorCategory { get; set; }
}