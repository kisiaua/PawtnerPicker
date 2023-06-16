using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using PawtnerPicker.Models.Domain;

namespace PawtnerPicker.Services;

public class CsvProcessingService : ICsvProcesssingService
{
    public IEnumerable<Breed> GetAll()
    {
        using var reader = new StreamReader("Data/akc-data.csv");
        var config = new CsvConfiguration(CultureInfo.InvariantCulture);
        using var csv = new CsvReader(reader, config);
        
        csv.Context.RegisterClassMap<BreedMap>();
        var records = csv.GetRecords<Breed>();
        
        return records.ToList();
    }
}