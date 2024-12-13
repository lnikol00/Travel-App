using Backend.Exceptions;
using Backend.Models;
using Backend.Services.EmployeeService;
using Backend.Services.EmployeeService.Models;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;

namespace Backend.Logic.EmployeeLogic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeService _employeeService;
        private readonly EmployeeValidation _validation;

        public EmployeeLogic(IEmployeeService employeeService, IOptions<EmployeeValidation> configuration)
        {
            _employeeService = employeeService;
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

        private void ValidateLastName(string? lastName)
        {
            if (lastName == null)
            {
                throw new ErrorMessage("Field can't be empty!");
            }

            if (lastName.Length > _validation.LastNameMaxCharacter)
            {
                throw new ErrorMessage("Exceeded maximum number of characters!");
            }

            if (!Regex.IsMatch(lastName, _validation.NameRegex))
            {
                throw new ErrorMessage("Invalid name format!");
            }
        }

        public async Task<Employee> CreateNewEmployee(Employee? employee)
        {
            if (employee is null)
            {
                throw new ErrorMessage("Cannot create a new employee. All fields must be entered correctly!");
            }

            ValidateName(employee.Name);
            ValidateLastName(employee.LastName);

            return await _employeeService.CreateNewEmployee(employee);
        }

        public async Task<Employee> UpdateEmployee(int id, Employee? employee)
        {
            if (employee is null)
            {
                throw new ErrorMessage("Cannot update! All fields must be entered correctly!");
            }

            ValidateName(employee.Name);
            ValidateLastName(employee.LastName);

            return await _employeeService.UpdateEmployee(id, employee);
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            return await _employeeService.DeleteEmployee(id);
        }

        public async Task<Employee> GetEmployeeByID(int id)
        {
            return await _employeeService.GetEmployeeByID(id);
        }

        public async Task<List<Employee>> GetAllEmployee()
        {
            return await _employeeService.GetAllEmployee();
        }
    }
}
