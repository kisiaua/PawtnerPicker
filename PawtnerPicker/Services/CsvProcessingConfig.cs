using System.Globalization;
using CsvHelper.Configuration;
using PawtnerPicker.Models.Domain;

namespace PawtnerPicker.Services;

public sealed class BreedMap : ClassMap<Breed>
{
    public BreedMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
        Map(m => m.Id).Ignore();
        Map(m => m.MinExpectancy).Convert(row =>
            (int)double.Parse(row.Row.GetField("MinExpectancy") ?? string.Empty, CultureInfo.InvariantCulture)
        );        
        Map(m => m.MaxExpectancy).Convert(row =>
            (int)double.Parse(row.Row.GetField("MaxExpectancy") ?? string.Empty, CultureInfo.InvariantCulture)
        );
    }
}

public sealed class GroomingFrequencyMap : ClassMap<GroomingFrequency>
{
    public GroomingFrequencyMap()
    {
        Map(m => m.GroomingFrequencyValue);
        Map(m => m.GroomingFrequencyCategory);
    }
}

public sealed class SheddingMap : ClassMap<Shedding>
{
    public SheddingMap()
    {
        Map(m => m.SheddingValue);
        Map(m => m.SheddingCategory);
    }
}
public sealed class EnergyMap : ClassMap<EnergyLevel>
{
    public EnergyMap()
    {
        Map(m => m.EnergyLevelValue);
        Map(m => m.EnergyLevelCategory);
    }
}

public sealed class TrainabilityMap : ClassMap<Trainability>
{
    public TrainabilityMap()
    {
        Map(m => m.TrainabilityValue);
        Map(m => m.TrainabilityCategory);
    }
}

public sealed class DemeanorMap : ClassMap<Demeanor>
{
    public DemeanorMap()
    {
        Map(m => m.DemeanorValue);
        Map(m => m.DemeanorCategory);
    }
}