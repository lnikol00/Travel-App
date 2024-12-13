namespace Backend.Services.TravelOrdersService.Models
{
    public class TravelOrders
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Brand { get; set; }
        public string Registration { get; set; }
        public DateTime Date { get; set; }
        public int Mileage { get; set; }
        public string Route { get; set; }
        public int EmployeeId { get; set; }
        public int CarsId { get; set; }
    }
}
