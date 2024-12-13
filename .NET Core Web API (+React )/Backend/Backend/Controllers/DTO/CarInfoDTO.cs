using Backend.Services.CarsService.Models;

namespace Backend.Controllers.DTO
{
    public class CarInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Registration { get; set; }

        public static CarInfoDTO FromModel(Cars model)
        {
            return new CarInfoDTO
            {
                Id = model.Id,
                Name = model.Name,
                Registration = model.Registration,
            };
        }
    }
}
