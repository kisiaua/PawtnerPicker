using System.ComponentModel.DataAnnotations;

namespace PawtnerPicker.Models.Validation;

public class MinMaxValidation : ValidationAttribute
{
    private readonly string _minPropertyName;
    private readonly string _maxPropertyName;

    public MinMaxValidation(string minPropertyName, string maxPropertyName)
    {
        _minPropertyName = minPropertyName;
        _maxPropertyName = maxPropertyName;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var minProperty = validationContext.ObjectType.GetProperty(_minPropertyName);
        var maxProperty = validationContext.ObjectType.GetProperty(_maxPropertyName);

        if (minProperty == null || maxProperty == null)
        {
            return new ValidationResult($"MinLessThanMax: Unknown property {_minPropertyName} or {_maxPropertyName}");
        }

        var minValue = (IComparable)minProperty.GetValue(validationContext.ObjectInstance)!;
        var maxValue = (IComparable)maxProperty.GetValue(validationContext.ObjectInstance)!;

        return minValue.CompareTo(maxValue) > 0 ? new ValidationResult(ErrorMessage) : ValidationResult.Success;
    }
}