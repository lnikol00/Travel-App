using Backend.Services.EmployeeService.Models;

namespace Backend.Controllers.DTO
{
    public class NewEmployeeDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public Employee ToModel()
        {
            return new Employee
            {
                Id = -1,
                Name = Name,
                LastName = LastName,
            };
        }
    }
}
