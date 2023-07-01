using System.Collections;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PawtnerPicker.Data;
using PawtnerPicker.Models.Domain;
using PawtnerPicker.Models.ViewModels;


namespace PawtnerPicker.Services;

public class PickBreedService : IPickBreedService
{
    private readonly DataContext _dataContext;

    public PickBreedService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Breed?>> GetRecommendations(PickBreedViewModel pickBreedViewModel)
    {
        var breeds = await _dataContext.Breeds.ToListAsync();
        var recommendedBreeds = ChooseRecommendations(pickBreedViewModel, breeds).ToList();
        return recommendedBreeds.Select(recommendedBreed => breeds.Find(x => x.BreedName == recommendedBreed)).ToList();
    }

    private static IEnumerable<string> ChooseRecommendations(PickBreedViewModel pickBreedViewModel, List<Breed> breeds)
    {
        var breedsValues = new Dictionary<string, double>();
        
        foreach (var breed in breeds)
        {
            var result = 0.0;
        
            foreach (var property in pickBreedViewModel.GetType().GetProperties())
            {
                var valuesVm = Convert.ToSingle(property.GetValue(pickBreedViewModel));
                var valuesModel = Convert.ToSingle(breed.GetType().GetProperty(property.Name)?.GetValue(breed));
        
                var value = valuesVm / valuesModel;
                switch (value)
                {
                    case <= 1:
                        result += value;
                        break;
                    case < 2:
                        result += 2 - value;
                        break;
                }
            }
        
            breedsValues.Add(breed.BreedName, result);
        }

        return breedsValues.OrderByDescending(x => x.Value)
            .Take(5)
            .Select(x => x.Key)
            .ToList();
    }
}