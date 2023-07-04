namespace PawtnerPicker.Models.Domain
{
    public class Authentication
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
