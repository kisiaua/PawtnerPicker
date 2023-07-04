using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
namespace PawtnerPicker.Models.Validation
{
    public class RegistrationValidation : ValidationAttribute
    {
        private readonly string _password;
        private readonly string _confirmPassword;

        public RegistrationValidation(string password, string confirmPassword)
        {
            _password = password;
            _confirmPassword = confirmPassword;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var pass = validationContext.ObjectType.GetProperty(_password);
            var confPass = validationContext.ObjectType.GetProperty(_confirmPassword);

            if (pass == null || confPass == null)
            {
                return new ValidationResult($"Register: Unknown property {_password} or {_confirmPassword}");
            }
            var value1 = (IComparable)pass.GetValue(validationContext.ObjectInstance)!;
            var value2 = (IComparable)confPass.GetValue(validationContext.ObjectInstance)!;

            return value1.CompareTo(value2) != 0 ? new ValidationResult(ErrorMessage) : ValidationResult.Success;
        }
    }
}
