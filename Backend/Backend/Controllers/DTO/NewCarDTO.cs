using Backend.Services.CarsService.Models;

namespace Backend.Controllers.DTO
{
    public class NewCarDTO
    {
        public string Name { get; set; }
        public string Registration { get; set; }

        public Cars ToModel()
        {
            return new Cars
            {
                Id = -1,
                Name = Name,
                Registration = Registration,
            };
        }
    }
}
