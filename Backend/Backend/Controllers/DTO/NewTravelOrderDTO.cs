using Backend.Services.TravelOrdersService.Models;

namespace Backend.Controllers.DTO
{
    public class NewTravelOrderDTO
    {
        public int EmployeeId { get; set; }
        public int CarsId { get; set; }
        public string Date { get; set; }
        public int Mileage { get; set; }
        public string Route { get; set; }

        public TravelOrderDB ToModel()
        {
            return new TravelOrderDB
            {
                EmployeeId = EmployeeId,
                CarsId = CarsId,
                Date = Date,
                Mileage = Mileage,
                Route = Route
            };
        }
    }
}
