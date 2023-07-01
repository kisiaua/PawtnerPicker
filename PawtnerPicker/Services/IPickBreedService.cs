using System.Collections;
using PawtnerPicker.Models.Domain;
using PawtnerPicker.Models.ViewModels;

namespace PawtnerPicker.Services;

public interface IPickBreedService
{
    Task<List<Breed?>> GetRecommendations(PickBreedViewModel pickBreedViewModel);
}