using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawtnerPicker.Data;
using PawtnerPicker.Models.Domain;
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
        if (!ModelState.IsValid) return View(pickBreedViewModel);
        var recommendations = await _pickBreedService.GetRecommendations(pickBreedViewModel);
        if (recommendations.Count > 0)
        {
            return View("Recommendations", recommendations);
        }

        TempData["NoRecommendations"] = "Database is empty or no recommendations found.";
        return RedirectToAction("Pick");
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
        var breed = await GetBreedById.GetBreedDetails(_dataContext, id);
        var urlImage = await FetchImage.GetImageUrl(breed.BreedName);

        var breedDetailsViewModel = new BreedDetailsViewModel
        {
            Breed = breed,
            UrlImage = urlImage
        };
        return View(breedDetailsViewModel);
    }

    [HttpGet]
    [Authorize(Policy = "RequireAdministratorRole")]
    public async Task<IActionResult> Edit(int id)
    {
        var breed = await GetBreedById.GetBreedDetails(_dataContext, id);
        return View(breed);
    }


    [HttpPost]
    [Authorize(Policy = "RequireAdministratorRole")]
    public async Task<IActionResult> Edit(Breed updateBreed)
    {
        var breed = await GetBreedById.GetBreedDetails(_dataContext, updateBreed.Id);
        UpdateBreedProps.Update(breed, updateBreed);
        if (!ModelState.IsValid) return View(breed);
        await _dataContext.SaveChangesAsync();
        return RedirectToAction("DisplayBreeds");
    }


    [HttpPost]
    [Authorize(Policy = "RequireAdministratorRole")]
    public async Task<IActionResult> Remove(int id)
    {
        var delBreed = await GetBreedById.GetBreedDetails(_dataContext, id);
        _dataContext.Breeds.Remove(delBreed);
        await _dataContext.SaveChangesAsync();
        return RedirectToAction("DisplayBreeds");
    }
}