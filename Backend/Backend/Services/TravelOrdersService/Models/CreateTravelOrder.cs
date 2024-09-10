namespace Backend.Services.TravelOrdersService.Models
{
    public class CreateTravelOrder
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int CarsId { get; set; }
        public DateTime Date { get; set; }
        public int Mileage { get; set; }
        public string Route { get; set; }
    }
}
