﻿using Backend.Services.EmployeeService.Models;

namespace Backend.Logic.EmployeeLogic
{
    public interface IEmployeeLogic
    {
        void CreateNewEmployee(Employee? employee);
        void DeleteEmployee(int id);
        IEnumerable<Employee> GetAllEmployee();
        Employee? GetEmployeeByID(int id);
        void UpdateEmployee(int id, Employee? employee);
    }
}