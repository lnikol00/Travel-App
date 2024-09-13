using Backend.Exceptions;
using Backend.Models;
using Backend.Services.CarsService;
using Backend.Services.CarsService.Models;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace Backend.Logic.CarsLogic
{
    public class CarsLogic : ICarsLogic
    {
        private readonly ICarsService _carsService;
        private readonly CarsValidation _validation;

        public CarsLogic(ICarsService carsService, IOptions<CarsValidation> configuration)
        {
            _carsService = carsService;
            _validation = configuration.Value;
        }

        private void ValidateName(string? name)
        {
            if (name == null)
            {
                throw new ErrorMessage("Field can't be empty!");
            }

            if (name.Length > _validation.NameMaxCharacters)
            {
                throw new ErrorMessage("Exceeded maximum number of characters!");
            }

            if (!Regex.IsMatch(name, _validation.NameRegex))
            {
                throw new ErrorMessage("Invalid name format!");
            }
        }

        private void ValidateRegistration(string? registration)
        {
            if (registration == null)
            {
                throw new ErrorMessage("Field can't be empty!");
            }

            if (registration.Length > _validation.RegistrationCharacters)
            {
                throw new ErrorMessage("Exceeded maximum number of characters!");
            }

            if (!Regex.IsMatch(registration, _validation.RegistrationRegex))
            {
                throw new ErrorMessage("Invalid registration format!");
            }
        }

        public void CreateNewCar(Cars? cars)
        {
            if (cars is null)
            {
                throw new ErrorMessage("Cannot add new car. All fields must be entered correctly!");
            }

            cars.Id = -1;
            ValidateName(cars.Name);
            ValidateRegistration(cars.Registration);

            _carsService.CreateNewCar(cars);
        }

        public void UpdateCar(int id, Cars? cars)
        {
            if (cars is null)
            {
                throw new ErrorMessage("Cannot update! All fields must be entered correctly!");
            }

            cars.Id = -1;
            ValidateName(cars.Name);
            ValidateRegistration(cars.Registration);

            _carsService.UpdateCar(id, cars);
        }

        public void DeleteCar(int id)
        {
            _carsService.DeleteCar(id);
        }

        public Cars? GetCarByID(int id)
        {
            return _carsService.GetCarByID(id);
        }

        public IEnumerable<Cars> GetAllCars()
        {
            return _carsService.GetAllCars();
        }
    }
}
