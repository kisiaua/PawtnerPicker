using Microsoft.AspNetCore.Mvc;

namespace PawtnerPicker.Controllers;

public class ManagementController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}