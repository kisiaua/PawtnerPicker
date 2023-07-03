using PawtnerPicker.Models.Domain;

namespace PawtnerPicker.Services;

public interface ICsvProcesssingService
{
    IEnumerable<Breed> GetBreed();
    IEnumerable<GroomingFrequency> GetGrooming();
    IEnumerable<Shedding> GetShedding();
    IEnumerable<EnergyLevel> GetEnergy();
    IEnumerable<Trainability> GetTrainability();
    IEnumerable<Demeanor> GetDemeanor();
}