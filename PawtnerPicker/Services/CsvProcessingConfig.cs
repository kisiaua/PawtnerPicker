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