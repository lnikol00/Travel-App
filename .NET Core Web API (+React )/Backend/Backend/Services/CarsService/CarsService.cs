using Backend.Exceptions;
using Backend.Services.CarsService.Models;
using Backend.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.CarsService
{
    public class CarsService : ICarsService
    {

        private DatabaseContext _db;

        public CarsService(DatabaseContext db)
        {
            _db = db;
        }

        // CREATE NEW CAR
        public async Task<Cars> CreateNewCar(Cars cars)
        {
            var car = new Cars()
            {
                Name = cars.Name,
                Registration = cars.Registration
            };

            var existingCar = await _db.Cars.FirstOrDefaultAsync(c => c.Name == car.Name && c.Registration == car.Registration);

            if (existingCar == null)
            {
                _db.Cars.Add(car);

                try
                {
                    await _db.SaveChangesAsync();
                }
                catch
                {
                    throw new ErrorMessage("An error occurred while connecting to the database.");
                }
            }
            else
            {
                throw new ErrorMessage("Car already exists!");
            }

            return car;

        }

        // DELETE CAR
        public async Task<Cars> DeleteCar(int id)
        {
            Cars car = await _db.Cars.FirstOrDefaultAsync(c => c.Id == id);

            bool isCarInTravelOrder = _db.TravelOrders.Any(x => x.CarsId == id);

            if (isCarInTravelOrder)
            {
                throw new ErrorMessage("Cannot delete this car! Active travel order exists.");
            }

            _db.Cars.Remove(car);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw new ErrorMessage("An error occurred while connecting to the database.");
            }

            return car;
        }


        // GET ALL CARS
        public async Task<List<Cars>> GetAllCars()
        {
            List<Cars> lstCars = new List<Cars>();

            var query = from car in _db.Cars
                        select car;

            var cars = query.ToList();

            foreach (var car in cars)
            {
                var model = new Cars()
                {
                    Id = car.Id,
                    Name = car.Name,
                    Registration = car.Registration
                };

                lstCars.Add(model);
            }

            return lstCars;
        }

        // GET BY ID 
        public async Task<Cars> GetCarByID(int id)
        {
            var query = from c in _db.Cars
                        where c.Id == id
                        select c;
            var car = await query.FirstOrDefaultAsync();

            if (car == null)
            {
                return null;
            }

            var model = new Cars()
            {
                Id = id,
                Name = car.Name,
                Registration = car.Registration,
            };

            return model;
        }

        // UPDATE CAR
        public async Task<Cars> UpdateCar(int id, Cars updatedCar)
        {
            Cars car = await _db.Cars.FirstOrDefaultAsync(c => c.Id == id);

            car.Name = updatedCar.Name;
            car.Registration = updatedCar.Registration;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw new ErrorMessage("An error occurred while connecting to the database.");
            }

            return updatedCar;
        }


    }
}
