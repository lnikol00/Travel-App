using Backend.Services.EmployeeService.Models;

namespace Backend.Logic.EmployeeLogic
{
    public interface IEmployeeLogic
    {
        Task<Employee> CreateNewEmployee(Employee? employee);
        Task<Employee> DeleteEmployee(int id);
        Task<List<Employee>> GetAllEmployee();
        Task<Employee> GetEmployeeByID(int id);
        Task<Employee> UpdateEmployee(int id, Employee? employee);
    }
}