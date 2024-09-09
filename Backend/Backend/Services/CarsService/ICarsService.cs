using Backend.Services.CarsService.Models;

namespace Backend.Services.CarsService
{
    public interface ICarsService
    {
        void CreateNewCar(Cars cars);
        void DeleteCar(int id);
        List<Cars> GetAllCars();
        void UpdateCar(int id, Cars updatedCar);
    }
}