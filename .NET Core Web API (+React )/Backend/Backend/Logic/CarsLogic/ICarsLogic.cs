using Backend.Services.CarsService.Models;

namespace Backend.Logic.CarsLogic
{
    public interface ICarsLogic
    {
        Task<Cars> CreateNewCar(Cars? cars);
        Task<Cars> DeleteCar(int id);
        Task<List<Cars>> GetAllCars();
        Task<Cars> GetCarByID(int id);
        Task<Cars> UpdateCar(int id, Cars? cars);
    }
}