namespace Backend.Models
{
    public class CarsValidation
    {
        public int NameMaxCharacters { get; set; }
        public string NameRegex { get; set; }
        public int RegistrationCharacters { get; set; }
        public string RegistrationRegex { get; set; }
    }
}
