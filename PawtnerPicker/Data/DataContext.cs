using Microsoft.EntityFrameworkCore;
using PawtnerPicker.Models.Domain;

namespace PawtnerPicker.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) {}
    
    public DbSet<Breed> Breeds { get; set; } = null!;
}