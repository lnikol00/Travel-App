using Backend.Services.TravelOrdersService.Models;

namespace Backend.Services.TravelOrdersService
{
    public interface ITravelOrdersService
    {
        void CreateTravelOrder(TravelOrders travelOrder);
        void DeleteTravelOrder(int id);
        List<TravelOrders> GetTravelOrders();
        TravelOrders? GetTravelOrderByID(int id);
        void UpdateTravelOrder(int id, TravelOrders updatedTravelOrder);
    }
}