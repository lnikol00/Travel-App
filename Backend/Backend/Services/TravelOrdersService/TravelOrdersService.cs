using Backend.Exceptions;
using Backend.Services.Models;
using Backend.Services.TravelOrdersService.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.TravelOrdersService
{
    public class TravelOrdersService : ITravelOrdersService
    {
        private DatabaseContext _db;
        private readonly string _dbDatetimeFormat = "yyyy-MM-dd";
        public TravelOrdersService(DatabaseContext db)
        {
            _db = db;
        }

        // Create new Travel Order
        public async Task<TravelOrderDB> CreateTravelOrder(TravelOrderDB travelOrder)
        {
            var order = new TravelOrderDB()
            {
                EmployeeId = travelOrder.EmployeeId,
                CarsId = travelOrder.CarsId,
                Date = travelOrder.Date,
                Route = travelOrder.Route,
                Mileage = travelOrder.Mileage
            };

            var existingTravelOrder = await _db.TravelOrders.FirstOrDefaultAsync(
                to => to.EmployeeId == travelOrder.EmployeeId
                && to.CarsId == travelOrder.CarsId
                && to.Date == travelOrder.Date
                && to.Route == travelOrder.Route
                && to.Mileage == travelOrder.Mileage);

            if (existingTravelOrder == null)
            {
                _db.TravelOrders.Add(order);

                try
                {
                    await _db.SaveChangesAsync();
                }
                catch
                {
                    throw new ErrorMessage("an error occurred while connecting to the database.");
                }
            }
            else
            {
                throw new ErrorMessage("Travel order already exists!");
            }


            return order;
        }

        // Get All Travel Orders
        public async Task<List<TravelOrders>> GetTravelOrders()
        {
            List<TravelOrders> lstTravelOrders = new List<TravelOrders>();

            var query = from travelOrders in _db.TravelOrders
                        join employee in _db.Employee on travelOrders.EmployeeId equals employee.Id
                        join car in _db.Cars on travelOrders.CarsId equals car.Id
                        select new
                        {
                            travelOrders.Id,
                            EmployeeName = employee.Name,
                            EmployeeLastName = employee.LastName,
                            CarBrand = car.Name,
                            CarRegistration = car.Registration,
                            Date = DateTime.ParseExact(travelOrders.Date.ToString(), _dbDatetimeFormat, null),
                            travelOrders.Mileage,
                            travelOrders.Route,
                            travelOrders.EmployeeId,
                            travelOrders.CarsId
                        };


            var orders = query.ToList();

            foreach (var order in orders)
            {
                var model = new TravelOrders()
                {
                    Id = order.Id,
                    Name = order.EmployeeName,
                    LastName = order.EmployeeLastName,
                    Brand = order.CarBrand,
                    Registration = order.CarRegistration,
                    Date = order.Date,
                    Mileage = order.Mileage,
                    Route = order.Route,
                    EmployeeId = order.EmployeeId,
                    CarsId = order.CarsId
                };
                lstTravelOrders.Add(model);
            }

            return lstTravelOrders;
        }

        // GET BY ID 
        public async Task<TravelOrders> GetTravelOrderByID(int id)
        {
            var query = from travelOrder in _db.TravelOrders
                        join employee in _db.Employee on travelOrder.EmployeeId equals employee.Id
                        join car in _db.Cars on travelOrder.CarsId equals car.Id
                        where travelOrder.Id == id
                        select new
                        {
                            travelOrder.Id,
                            EmployeeName = employee.Name,
                            EmployeeLastName = employee.LastName,
                            CarBrand = car.Name,
                            CarRegistration = car.Registration,
                            Date = DateTime.ParseExact(travelOrder.Date.ToString(), _dbDatetimeFormat, null),
                            travelOrder.Mileage,
                            travelOrder.Route,
                            travelOrder.EmployeeId,
                            travelOrder.CarsId
                        };

            var order = await query.FirstOrDefaultAsync();

            if (order == null)
            {
                return null;
            }

            var model = new TravelOrders()
            {
                Id = order.Id,
                Name = order.EmployeeName,
                LastName = order.EmployeeLastName,
                Brand = order.CarBrand,
                Registration = order.CarRegistration,
                Date = order.Date,
                Mileage = order.Mileage,
                Route = order.Route,
                EmployeeId = order.EmployeeId,
                CarsId = order.CarsId,
            };

            return model;
        }

        // Delete Travel Order
        public async Task<TravelOrderDB> DeleteTravelOrder(int id)
        {
            TravelOrderDB order = await _db.TravelOrders.FirstOrDefaultAsync(to => to.Id == id);

            _db.TravelOrders.Remove(order);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw new ErrorMessage("An error occurred while connecting to the database.");
            }

            return order;
        }

        // Update Travel Order
        public async Task<TravelOrderDB> UpdateTravelOrder(int id, TravelOrderDB updatedTravelOrder)
        {
            TravelOrderDB order = await _db.TravelOrders.FirstOrDefaultAsync(to => to.Id == id);

            order.EmployeeId = updatedTravelOrder.EmployeeId;
            order.CarsId = updatedTravelOrder.CarsId;
            order.Date = updatedTravelOrder.Date;
            order.Mileage = updatedTravelOrder.Mileage;
            order.Route = updatedTravelOrder.Route;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw new ErrorMessage("An error occurred while connecting to the database.");
            }

            return updatedTravelOrder;

        }
    }
}
