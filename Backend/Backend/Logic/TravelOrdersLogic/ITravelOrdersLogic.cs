using Backend.Services.TravelOrdersService.Models;

namespace Backend.Logic.TravelOrdersLogic
{
    public interface ITravelOrdersLogic
    {
        void CreateTravelOrder(CreateTravelOrder? travelOrder);
        void DeleteTravelOrder(int id);
        IEnumerable<TravelOrders> GetTravelOrders();
        void UpdateTravelOrder(int id, CreateTravelOrder? travelOrder);
    }
}