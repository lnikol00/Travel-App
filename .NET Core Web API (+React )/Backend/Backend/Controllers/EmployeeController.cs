using Backend.Controllers.DTO;
using Backend.Filters;
using Backend.Logic.EmployeeLogic;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [LogFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeLogic _employeeLogic;

        public EmployeeController(IEmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
        }

        // CREATE
        [HttpPost]
        public async Task<ActionResult> CreateNewEmployee([FromBody] NewEmployeeDTO employee)
        {
            if (employee == null)
            {
                return BadRequest($"Incorect format!");

            }
            await _employeeLogic.CreateNewEmployee(employee.ToModel());

            return Ok();
        }

        // READ
        [HttpGet]
        public async Task<ActionResult<List<EmployeeInfoDTO>>> GetAllEmployee()
        {
            var allEmployee = await _employeeLogic.GetAllEmployee();

            var driverInfoDTOs = allEmployee.Select(x => EmployeeInfoDTO.FromModel(x));

            return Ok(allEmployee);
        }

        // READ BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeInfoDTO>> GetEmployeeByID(int id)
        {
            var employee = await _employeeLogic.GetEmployeeByID(id);

            if (employee is null)
            {
                return NotFound($"Employee with id:{id} doesn't exist!");
            }
            else
            {
                return Ok(EmployeeInfoDTO.FromModel(employee));
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeeLogic.DeleteEmployee(id);

            return Ok();
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] NewEmployeeDTO updatedEmployee)
        {
            if (updatedEmployee == null)
            {
                return BadRequest();
            }

            await _employeeLogic.UpdateEmployee(id, updatedEmployee.ToModel());

            return Ok();
        }
    }
}