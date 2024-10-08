﻿using Backend.Services.EmployeeService.Models;

namespace Backend.Services.EmployeeService
{
    public interface IEmployeeService
    {
        void CreateNewEmployee(Employee employee);
        void DeleteEmployee(int id);
        List<Employee> GetAllEmployee();
        Employee? GetEmployeeByID(int id);
        void UpdateEmployee(int id, Employee updatedEmployee);
    }
}