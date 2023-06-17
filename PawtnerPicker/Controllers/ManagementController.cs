using Microsoft.AspNetCore.Mvc;
using PawtnerPicker.Data;
using PawtnerPicker.Services;

namespace PawtnerPicker.Controllers;

public class ManagementController : Controller
{
    private readonly DataContext _dataContext;
    private readonly ICsvProcesssingService _service;

    public ManagementController(DataContext dataContext, ICsvProcesssingService service)
    {
        _dataContext = dataContext;
        _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Add()
    {
        if (!_dataContext.Breeds.Any())
        {
            var csvData = _service.GetAll();
            _dataContext.Breeds.AddRange(csvData);
            _dataContext.SaveChanges();
        }
        else
        {
            TempData["ErrorAddTable"] = "Table breeds already exist in the database.";
        }

        return RedirectToAction("Index");
    }

    public IActionResult Delete()
    {
        if (_dataContext.Breeds.Any())
        {
            _dataContext.Breeds.RemoveRange(_dataContext.Breeds);
            _dataContext.SaveChanges();
        }
        else
        {
            TempData["ErrorDeleteTable"] = "Table breeds does not exist in the database.";
        }

        return RedirectToAction("Index");
    }

    public IActionResult Restore()
    {
        Delete();
        Add();
        TempData["ErrorAddTable"] = "";
        TempData["ErrorDeleteTable"] = "";
        return RedirectToAction("Index");
    }
}