using PawtnerPicker.Models.Domain;

namespace PawtnerPicker.Services;

public interface ICsvProcesssingService
{
    IEnumerable<Breed> GetAll();
}