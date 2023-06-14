using Microsoft.AspNetCore.Mvc;
using PawtnerPicker.Models.ViewModels;

namespace PawtnerPicker.Controllers;

public class BreedsController : Controller
{
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