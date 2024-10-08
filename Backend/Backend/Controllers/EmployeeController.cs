﻿using Backend.Controllers.DTO;
using Backend.Exceptions;
using Backend.Filters;
using Backend.Logic.EmployeeLogic;
using Backend.Logic.TravelOrdersLogic;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [LogFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ITravelOrdersLogic _travelOrdersLogic;
        private readonly IEmployeeLogic _employeeLogic;

        public EmployeeController(IEmployeeLogic employeeLogic, ITravelOrdersLogic travelOrdersLogic)
        {
            _employeeLogic = employeeLogic;
            _travelOrdersLogic = travelOrdersLogic;
        }

        // CREATE
        [HttpPost]
        public ActionResult CreateNewEmployee([FromBody] NewEmployeeDTO employee)
        {
            if (employee == null)
            {
                return BadRequest($"Incorect format!");

            }
            _employeeLogic.CreateNewEmployee(employee.ToModel());

            return Ok();
        }

        // READ
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeInfoDTO>> GetAllEmployee()
        {
            var allEmployee = _employeeLogic.GetAllEmployee().Select(x => EmployeeInfoDTO.FromModel(x));
            return Ok(allEmployee);
        }

        // READ BY ID
        [HttpGet("{id}")]
        public ActionResult<EmployeeInfoDTO> GetEmployeeByID(int id)
        {
            var employee = _employeeLogic.GetEmployeeByID(id);

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
        public ActionResult DeleteEmployee(int id)
        {
            bool isEmployeeInTravelOrder = _travelOrdersLogic.GetTravelOrders().Any(x => x.EmployeeId == id);

            if (isEmployeeInTravelOrder)
            {
                throw new ErrorMessage("Cannot delete this driver! Active travel order exists.");
            }


            _employeeLogic.DeleteEmployee(id);

            return Ok();
        }

        // UPDATE
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, [FromBody] NewEmployeeDTO updatedEmployee)
        {
            if (updatedEmployee == null)
            {
                return BadRequest();
            }

            _employeeLogic.UpdateEmployee(id, updatedEmployee.ToModel());

            return Ok();
        }
    }
}