using Microsoft.AspNetCore.Authorization;
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

    public async Task<IActionResult> Add()
    {
        if (!_dataContext.Breeds.Any())
        {
            var csvData = _service.GetAll();
            await _dataContext.Breeds.AddRangeAsync(csvData);
            await _dataContext.SaveChangesAsync();
        }
        else
        {
            TempData["ErrorAddTable"] = "Table breeds already exist in the database.";
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete()
    {
        if (_dataContext.Breeds.Any())
        {
            _dataContext.Breeds.RemoveRange(_dataContext.Breeds);
            await _dataContext.SaveChangesAsync();
        }
        else
        {
            TempData["ErrorDeleteTable"] = "Table breeds does not exist in the database.";
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Restore()
    {
        await Delete();
        await Add();
        TempData["ErrorAddTable"] = "";
        TempData["ErrorDeleteTable"] = "";
        return RedirectToAction("Index");
    }
}