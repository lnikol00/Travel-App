using Backend.Services.EmployeeService.Models;

namespace Backend.Controllers.DTO
{
    public class EmployeeInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public static EmployeeInfoDTO FromModel(Employee model)
        {
            return new EmployeeInfoDTO
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
            };
        }
    }
}
