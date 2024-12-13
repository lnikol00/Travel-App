using Backend.Exceptions;
using Backend.Models;
using Backend.Services.TravelOrdersService;
using Backend.Services.TravelOrdersService.Models;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;


namespace Backend.Logic.TravelOrdersLogic
{
    public class TravelOrdersLogic : ITravelOrdersLogic
    {
        private readonly ITravelOrdersService _travelOrderService;
        private readonly TravelOrderValidation _validation;


        public TravelOrdersLogic(ITravelOrdersService travelOrdersService, IOptions<TravelOrderValidation> configuration)
        {
            _travelOrderService = travelOrdersService;
            _validation = configuration.Value;
        }

        private void ValidateMileage(int mileage)
        {
            if (mileage.ToString() is null)
            {
                throw new ErrorMessage("Field can't be empty!");
            }

            if (mileage < 0)
            {
                throw new ErrorMessage("Mileage can't be less then 0!");
            }

            if (mileage.ToString().Length > 4)
            {
                throw new ErrorMessage("Mileage can't exceed 9999km");
            }

            if (!Regex.IsMatch(mileage.ToString(), _validation.MileageRegex))
            {
                throw new ErrorMessage("Invalid year format! Year must begin with either number 1 or number 2!");
            }
        }

        private void ValidateRoute(string? route)
        {
            if (route == null)
            {
                throw new ErrorMessage("Field can't be empty!");
            }

            if (!Regex.IsMatch(route, _validation.RouteRegex))
            {
                throw new ErrorMessage("Invalid route format!");
            }
        }

        private void ValidateDate(string date)
        {
            if (date == null)
            {
                throw new ErrorMessage("Field can't be empty");
            }

            if (DateTime.Parse(date) < DateTime.UtcNow)
            {
                throw new ErrorMessage("Invalid date!");
            }
        }

        public async Task<TravelOrderDB> CreateTravelOrder(TravelOrderDB? travelOrder)
        {
            if (travelOrder is null)
            {
                throw new ErrorMessage("Cannot create new travel order. All fields must be entered correctly!");
            }

            _ = travelOrder.EmployeeId;
            _ = travelOrder.CarsId;
            ValidateDate(travelOrder.Date);
            ValidateMileage(travelOrder.Mileage);
            ValidateRoute(travelOrder.Route);

            return await _travelOrderService.CreateTravelOrder(travelOrder);
        }

        public async Task<TravelOrderDB> UpdateTravelOrder(int id, TravelOrderDB? travelOrder)
        {
            if (travelOrder is null)
            {
                throw new ErrorMessage("Cannot update! All fields must be entered correctly!");
            }

            _ = travelOrder.EmployeeId;
            _ = travelOrder.CarsId;
            ValidateDate(travelOrder.Date);
            ValidateMileage(travelOrder.Mileage);
            ValidateRoute(travelOrder.Route);

            return await _travelOrderService.UpdateTravelOrder(id, travelOrder);
        }

        public async Task<TravelOrderDB> DeleteTravelOrder(int id)
        {
            return await _travelOrderService.DeleteTravelOrder(id);
        }

        public async Task<TravelOrders> GetTravelOrderByID(int id)
        {
            return await _travelOrderService.GetTravelOrderByID(id);
        }

        public async Task<List<TravelOrders>> GetTravelOrders()
        {
            return await _travelOrderService.GetTravelOrders();
        }
    }
}
