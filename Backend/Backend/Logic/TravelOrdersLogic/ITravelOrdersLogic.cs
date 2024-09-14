using Backend.Services.TravelOrdersService.Models;

namespace Backend.Logic.TravelOrdersLogic
{
    public interface ITravelOrdersLogic
    {
        void CreateTravelOrder(TravelOrders? travelOrder);
        void DeleteTravelOrder(int id);
        IEnumerable<TravelOrders> GetTravelOrders();
        TravelOrders? GetTravelOrderByID(int id);
        void UpdateTravelOrder(int id, TravelOrders? travelOrder);
    }
}