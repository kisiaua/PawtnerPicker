using PawtnerPicker.Models.Domain;

namespace PawtnerPicker.Data;

public static class UpdateBreedProps
{
    public static void Update(Breed breed, Breed updatedBreed)
    {
        foreach (var property in typeof(Breed).GetProperties())
        {
            var newValue = property.GetValue(updatedBreed);

            if (newValue != null && newValue != property.GetValue(breed))
            {
                property.SetValue(breed, newValue);
            }
        }
    }
}