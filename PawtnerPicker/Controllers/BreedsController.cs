using Microsoft.AspNetCore.Mvc;
using PawtnerPicker.Models.ViewModels;
using PawtnerPicker.Services;

namespace PawtnerPicker.Controllers;

public class BreedsController : Controller
{

    private readonly ICsvProcesssingService _service;

    public BreedsController(ICsvProcesssingService service)
    {
        _service = service;
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
}