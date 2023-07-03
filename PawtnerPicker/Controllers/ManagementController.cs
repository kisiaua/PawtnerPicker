using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawtnerPicker.Data;
using PawtnerPicker.Models.Domain;
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
        var csvGrooming = _service.GetGrooming()
            .GroupBy(r => r.GroomingFrequencyValue)
            .Select(g => g.First())
            .ToList();
        var csvShedding = _service.GetShedding()
            .GroupBy(r => r.SheddingValue)
            .Select(g => g.First())
            .ToList();
        var csvEnergy = _service.GetEnergy()
            .GroupBy(r => r.EnergyLevelValue)
            .Select(g => g.First())
            .ToList();
        var csvTrainability = _service.GetTrainability()
            .GroupBy(r => r.TrainabilityValue)
            .Select(g => g.First())
            .ToList();
        var csvDemeanor = _service.GetDemeanor()
            .GroupBy(r => r.DemeanorValue)
            .Select(g => g.First())
            .ToList();
        var csvBreed = _service.GetBreed();
        
        if (!_dataContext.Breeds.Any())
        {
            await _dataContext.GroomingFrequencies.AddRangeAsync(csvGrooming);
            await _dataContext.Sheddings.AddRangeAsync(csvShedding);
            await _dataContext.EnergyLevels.AddRangeAsync(csvEnergy);
            await _dataContext.Trainabilities.AddRangeAsync(csvTrainability);
            await _dataContext.Demeanors.AddRangeAsync(csvDemeanor);
            await _dataContext.Breeds.AddRangeAsync(csvBreed);
            await _dataContext.SaveChangesAsync();
        }
        else
        {
            TempData["ErrorAddTable"] = "Tables already exist in the database.";
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete()
    {
        if (_dataContext.Breeds.Any())
        {
            _dataContext.Breeds.RemoveRange(_dataContext.Breeds);
            _dataContext.GroomingFrequencies.RemoveRange(_dataContext.GroomingFrequencies);
            _dataContext.Sheddings.RemoveRange(_dataContext.Sheddings);
            _dataContext.EnergyLevels.RemoveRange(_dataContext.EnergyLevels);
            _dataContext.Trainabilities.RemoveRange(_dataContext.Trainabilities);
            _dataContext.Demeanors.RemoveRange(_dataContext.Demeanors);
            await _dataContext.SaveChangesAsync();
        }
        else
        {
            TempData["ErrorDeleteTable"] = "Tables does not exist in the database.";
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