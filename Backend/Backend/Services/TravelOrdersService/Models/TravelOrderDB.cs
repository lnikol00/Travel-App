namespace Backend.Services.TravelOrdersService.Models
{
    public class TravelOrderDB
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Mileage { get; set; }
        public string Route { get; set; }
        public int EmployeeId { get; set; }
        public int CarsId { get; set; }
    }
}
