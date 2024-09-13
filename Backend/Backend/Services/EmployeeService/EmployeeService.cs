using Backend.Models;
using Backend.Services.EmployeeService.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Backend.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly string _connectionDB;

        public EmployeeService(IOptions<DBConfiguration> configuration)
        {
            _connectionDB = configuration.Value.ConnectionDB;
        }

        // CREATE NEW EMPLOYEE
        public void CreateNewEmployee(Employee employee)
        {
            using var connection = new SqlConnection(_connectionDB);
            using var command = new SqlCommand("[dbo].[CreateEmployee]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@LastName", employee.LastName);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return;
        }

        // DELETE EMPLOYEE
        public void DeleteEmployee(int id)
        {
            using var connection = new SqlConnection(_connectionDB);
            using var command = new SqlCommand("[dbo].[DeleteEmployee]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                throw new ArgumentException($"No employee with ID = {id}.");
            }

            connection.Close();
        }

        // GET ALL EMPLOYEE
        public List<Employee> GetAllEmployee()
        {
            using var connection = new SqlConnection(_connectionDB);
            using var command = new SqlCommand("[dbo].[GetAllEmployee]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            connection.Open();
            using var reader = command.ExecuteReader();

            var lstEmployee = new List<Employee>();

            while (reader.Read())
            {
                var employee = new Employee
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    LastName = reader.GetString(2),
                };

                lstEmployee.Add(employee);
            }

            connection.Close();
            return lstEmployee;
        }

        // GET BY ID 
        public Employee? GetEmployeeByID(int id)
        {
            using var connection = new SqlConnection(_connectionDB);
            using var command = new SqlCommand("[dbo].[GetEmployeeById]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using var reader = command.ExecuteReader();

            Employee employee = null;

            if (reader.Read())
            {
                employee = new Employee
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    LastName = reader.GetString(2),
                };
            }
            connection.Close();
            return employee;
        }

        // UPDATE EMPLOYEE
        public void UpdateEmployee(int id, Employee updatedEmployee)
        {
            using var connection = new SqlConnection(_connectionDB);
            using var command = new SqlCommand("[dbo].[UpdateEmployee]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@Name", updatedEmployee.Name);
            command.Parameters.AddWithValue("@LastName", updatedEmployee.LastName);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return;
        }
    }
}
