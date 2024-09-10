using Backend.Services.TravelOrdersService.Models;

namespace Backend.Controllers.DTO
{
    public class TravelOrderInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Brand { get; set; }
        public string Registration { get; set; }
        public DateTime Date { get; set; }
        public int Mileage { get; set; }
        public string Route { get; set; }

        public static TravelOrderInfoDTO FromModel(TravelOrders model)
        {
            return new TravelOrderInfoDTO
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                Brand = model.Brand,
                Registration = model.Registration,
                Date = model.Date,
                Mileage = model.Mileage,
                Route = model.Route,
            };
        }
    }
}
