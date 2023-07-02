using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawtnerPicker.Data;
using PawtnerPicker.Models.ViewModels;
using PawtnerPicker.Services;

namespace PawtnerPicker.Controllers;

public class BreedsController : Controller
{

    private readonly DataContext _dataContext;
    private readonly IPickBreedService _pickBreedService;

    public BreedsController(DataContext dataContext, IPickBreedService pickBreedService)
    {
        _dataContext = dataContext;
        _pickBreedService = pickBreedService;
    }

    [HttpGet]
    public IActionResult Pick()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Pick(PickBreedViewModel pickBreedViewModel)
    {
        var recommendations = await _pickBreedService.GetRecommendations(pickBreedViewModel);
        return View("Recommendations", recommendations);
    }
    
    [HttpGet]
    public async Task<IActionResult> DisplayBreeds()
    {
        var breeds = await _dataContext.Breeds.ToListAsync();
        return View(breeds);
    }
    
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var breed = await _dataContext.Breeds.FindAsync(id);
        var urlImage = await FetchImage.GetImageUrl(breed.BreedName);
        
        var breedDetailsViewModel = new BreedDetailsViewModel
        {
            Breed = breed,
            UrlImage = urlImage
        };
        return View(breedDetailsViewModel);
    }
}