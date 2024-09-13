using Backend.Services.CarsService.Models;

namespace Backend.Logic.CarsLogic
{
    public interface ICarsLogic
    {
        void CreateNewCar(Cars? cars);
        void DeleteCar(int id);
        IEnumerable<Cars> GetAllCars();
        Cars? GetCarByID(int id);
        void UpdateCar(int id, Cars? cars);
    }
}