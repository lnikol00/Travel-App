using Backend.Exceptions;
using Backend.Services.EmployeeService.Models;
using Backend.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private DatabaseContext _db;

        public EmployeeService(DatabaseContext db)
        {
            _db = db;
        }

        // CREATE NEW EMPLOYEE
        public async Task<Employee> CreateNewEmployee(Employee employee)
        {
            var driver = new Employee()
            {
                Name = employee.Name,
                LastName = employee.LastName
            };

            var existingDriver = await _db.Employee.FirstOrDefaultAsync(e => e.Name == employee.Name && e.LastName == employee.LastName);

            if (existingDriver == null)
            {
                _db.Employee.Add(driver);

                try
                {
                    await _db.SaveChangesAsync();
                }
                catch
                {
                    throw new ErrorMessage("An error occurred while connecting to the database.");
                }
            }
            else
            {
                throw new ErrorMessage("Driver already exists!");
            }

            return driver;
        }

        // DELETE EMPLOYEE
        public async Task<Employee> DeleteEmployee(int id)
        {
            Employee driver = await _db.Employee.FirstOrDefaultAsync(e => e.Id == id);

            bool isEmployeeInTravelOrder = _db.TravelOrders.Any(x => x.EmployeeId == id);

            if (isEmployeeInTravelOrder)
            {
                throw new ErrorMessage("Cannot delete this driver! Active travel order exists.");
            }

            _db.Employee.Remove(driver);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw new ErrorMessage("An error occurred while connecting to the database.");
            }

            return driver;
        }

        // GET ALL EMPLOYEE
        public async Task<List<Employee>> GetAllEmployee()
        {
            List<Employee> lstEmployee = new List<Employee>();

            var query = from employee in _db.Employee
                        select employee;

            var drivers = query.ToList();

            foreach (var driver in drivers)
            {
                var model = new Employee()
                {
                    Id = driver.Id,
                    Name = driver.Name,
                    LastName = driver.LastName
                };

                lstEmployee.Add(model);
            }

            return lstEmployee;
        }

        // GET BY ID 
        public async Task<Employee> GetEmployeeByID(int id)
        {
            var query = from e in _db.Employee
                        where e.Id == id
                        select e;

            var driver = await query.FirstOrDefaultAsync();

            if (driver == null)
            {
                return null;
            }

            var model = new Employee()
            {
                Id = id,
                Name = driver.Name,
                LastName = driver.LastName,
            };

            return model;

        }

        // UPDATE EMPLOYEE
        public async Task<Employee> UpdateEmployee(int id, Employee updatedEmployee)
        {
            Employee driver = await _db.Employee.FirstOrDefaultAsync(e => e.Id == id);

            driver.Name = updatedEmployee.Name;
            driver.LastName = updatedEmployee.LastName;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch
            {
                throw new ErrorMessage("An error occurred while connecting to the database.");
            }

            return updatedEmployee;
        }
    }
}
