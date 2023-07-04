using PawtnerPicker.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace PawtnerPicker.Models.ViewModels
{
    public class RegisterViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        [RegistrationValidation("Password", "ConfirmPassword", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
        [RegistrationValidation("Password", "ConfirmPassword", ErrorMessage = "Passwords do not match.")]
        public string EmployeeCode { get; set; }
    }
}
