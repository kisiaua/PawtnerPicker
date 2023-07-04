using PawtnerPicker.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace PawtnerPicker.Models.ViewModels
{
    public class RegisterViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string EmployeeCode { get; set; }
    }
}
