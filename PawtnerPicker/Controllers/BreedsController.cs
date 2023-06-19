using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawtnerPicker.Data;
using PawtnerPicker.Models.ViewModels;

namespace PawtnerPicker.Controllers;

public class BreedsController : Controller
{

    private readonly DataContext _dataContext;

    public BreedsController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public IActionResult Pick()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Pick(PickBreedViewModel pickBreedViewModel)
    {
        return RedirectToAction("Index", "Home");
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
        return View(breed);
    }
}