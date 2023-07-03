using Microsoft.EntityFrameworkCore;
using PawtnerPicker.Models.Domain;

namespace PawtnerPicker.Data;

public static class GetBreedById
{
    public static async Task<Breed> GetBreedDetails(DataContext dataContext, int id)
    {
        return (await dataContext.Breeds
            .Include(b => b.GroomingFrequency)
            .Include(b => b.GroomingFrequency)
            .Include(b => b.Shedding)
            .Include(b => b.EnergyLevel)
            .Include(b => b.Trainability)
            .Include(b => b.Demeanor)
            .FirstOrDefaultAsync(b => b.Id == id))!;
    }
}