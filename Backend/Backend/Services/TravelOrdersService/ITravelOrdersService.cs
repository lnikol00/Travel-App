﻿using Backend.Services.TravelOrdersService.Models;

namespace Backend.Services.TravelOrdersService
{
    public interface ITravelOrdersService
    {
        void CreateTravelOrder(CreateTravelOrder travelOrder);
        void DeleteTravelOrder(int id);
        List<TravelOrders> GetTravelOrders();
        void UpdateTravelOrder(int id, CreateTravelOrder updatedTravelOrder);
    }
}