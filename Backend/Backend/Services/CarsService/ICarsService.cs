using Backend.Services.CarsService.Models;

namespace Backend.Services.CarsService
{
    public interface ICarsService
    {
        void CreateNewCar(Cars cars);
        void DeleteCar(int id);
        List<Cars> GetAllCars();
        Cars? GetCarByID(int id);
        void UpdateCar(int id, Cars updatedCar);
    }
}