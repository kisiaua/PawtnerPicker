using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using PawtnerPicker.Models.Domain;

namespace PawtnerPicker.Services;

public class CsvProcessingService : ICsvProcesssingService
{
    public IEnumerable<Breed> GetBreed()
    {
        using var reader = new StreamReader("Data/akc-data.csv");
        var config = new CsvConfiguration(CultureInfo.InvariantCulture);
        using var csv = new CsvReader(reader, config);
        
        csv.Context.RegisterClassMap<BreedMap>();
        var records = csv.GetRecords<Breed>();
        
        return records.ToList();
    }
    
    public IEnumerable<GroomingFrequency> GetGrooming()
    {
        using var reader = new StreamReader("Data/akc-data.csv");
        var config = new CsvConfiguration(CultureInfo.InvariantCulture);
        using var csv = new CsvReader(reader, config);
        
        csv.Context.RegisterClassMap<GroomingFrequencyMap>();
        var records = csv.GetRecords<GroomingFrequency>();
        
        return records.ToList();
    }
    
    public IEnumerable<Shedding> GetShedding()
    {
        using var reader = new StreamReader("Data/akc-data.csv");
        var config = new CsvConfiguration(CultureInfo.InvariantCulture);
        using var csv = new CsvReader(reader, config);
        
        csv.Context.RegisterClassMap<SheddingMap>();
        var records = csv.GetRecords<Shedding>();
        
        return records.ToList();
    }
    
    public IEnumerable<EnergyLevel> GetEnergy()
    {
        using var reader = new StreamReader("Data/akc-data.csv");
        var config = new CsvConfiguration(CultureInfo.InvariantCulture);
        using var csv = new CsvReader(reader, config);
        
        csv.Context.RegisterClassMap<EnergyMap>();
        var records = csv.GetRecords<EnergyLevel>();
        
        return records.ToList();
    }
    
    public IEnumerable<Trainability> GetTrainability()
    {
        using var reader = new StreamReader("Data/akc-data.csv");
        var config = new CsvConfiguration(CultureInfo.InvariantCulture);
        using var csv = new CsvReader(reader, config);
        
        csv.Context.RegisterClassMap<TrainabilityMap>();
        var records = csv.GetRecords<Trainability>();
        
        return records.ToList();
    }
    
    public IEnumerable<Demeanor> GetDemeanor()
    {
        using var reader = new StreamReader("Data/akc-data.csv");
        var config = new CsvConfiguration(CultureInfo.InvariantCulture);
        using var csv = new CsvReader(reader, config);
        
        csv.Context.RegisterClassMap<DemeanorMap>();
        var records = csv.GetRecords<Demeanor>();
        
        return records.ToList();
    }

}