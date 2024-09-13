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

        private void ValidateDate(DateTime date)
        {
            if (date == null)
            {
                throw new ErrorMessage("Field can't be empty");
            }

            if (date < DateTime.UtcNow)
            {
                throw new ErrorMessage("Invalid date!");
            }
        }

        public void CreateTravelOrder(CreateTravelOrder? travelOrder)
        {
            if (travelOrder is null)
            {
                throw new ErrorMessage("Cannot create new travel order. All fields must be entered correctly!");
            }

            travelOrder.Id = -1;
            _ = travelOrder.EmployeeId;
            _ = travelOrder.CarsId;
            ValidateDate(travelOrder.Date);
            ValidateMileage(travelOrder.Mileage);
            ValidateRoute(travelOrder.Route);

            _travelOrderService.CreateTravelOrder(travelOrder);
        }

        public void UpdateTravelOrder(int id, CreateTravelOrder? travelOrder)
        {
            if (travelOrder is null)
            {
                throw new ErrorMessage("Cannot update! All fields must be entered correctly!");
            }

            travelOrder.Id = -1;
            _ = travelOrder.EmployeeId;
            _ = travelOrder.CarsId;
            ValidateDate(travelOrder.Date);
            ValidateMileage(travelOrder.Mileage);
            ValidateRoute(travelOrder.Route);

            _travelOrderService.UpdateTravelOrder(id, travelOrder);
        }

        public void DeleteTravelOrder(int id)
        {
            _travelOrderService.DeleteTravelOrder(id);
        }

        public TravelOrders? GetTravelOrderByID(int id)
        {
            return _travelOrderService.GetTravelOrderByID(id);
        }

        public IEnumerable<TravelOrders> GetTravelOrders()
        {
            return _travelOrderService.GetTravelOrders();
        }
    }
}
