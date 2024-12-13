using Backend.Services.TravelOrdersService.Models;

namespace Backend.Services.TravelOrdersService
{
    public interface ITravelOrdersService
    {
        Task<TravelOrderDB> CreateTravelOrder(TravelOrderDB travelOrder);
        Task<TravelOrderDB> DeleteTravelOrder(int id);
        Task<List<TravelOrders>> GetTravelOrders();
        Task<TravelOrders> GetTravelOrderByID(int id);
        Task<TravelOrderDB> UpdateTravelOrder(int id, TravelOrderDB updatedTravelOrder);
    }
}