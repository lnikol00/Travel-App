using Backend.Models;
using Backend.Services.CarsService.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Backend.Services.CarsService
{
    public class CarsService : ICarsService
    {
        private readonly string _connectionDB;

        public CarsService(IOptions<DBConfiguration> configuration)
        {
            _connectionDB = configuration.Value.ConnectionDB;
        }

        // CREATE NEW CAR
        public void CreateNewCar(Cars cars)
        {
            using var connection = new SqlConnection(_connectionDB);
            using var command = new SqlCommand("[dbo].[CreateCars]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Name", cars.Name);
            command.Parameters.AddWithValue("@Registration", cars.Registration);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return;
        }

        // DELETE CAR
        public void DeleteCar(int id)
        {
            using var connection = new SqlConnection(_connectionDB);
            using var command = new SqlCommand("[dbo].[DeleteCars]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                throw new ArgumentException($"No car with ID = {id}.");
            }

            connection.Close();
        }

        // GET ALL CARS
        public List<Cars> GetAllCars()
        {
            using var connection = new SqlConnection(_connectionDB);
            using var command = new SqlCommand("[dbo].[GetAllCars]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            connection.Open();
            using var reader = command.ExecuteReader();

            var lstCars = new List<Cars>();

            while (reader.Read())
            {
                var cars = new Cars
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Registration = reader.GetString(2),
                };

                lstCars.Add(cars);
            }

            connection.Close();
            return lstCars;
        }

        // GET BY ID 
        public Cars? GetCarByID(int id)
        {
            using var connection = new SqlConnection(_connectionDB);
            using var command = new SqlCommand("[dbo].[GetCarById]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using var reader = command.ExecuteReader();

            Cars car = null;

            if (reader.Read())
            {
                car = new Cars
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Registration = reader.GetString(2),
                };
            }
            connection.Close();
            return car;
        }


        // UPDATE CAR
        public void UpdateCar(int id, Cars updatedCar)
        {
            using var connection = new SqlConnection(_connectionDB);
            using var command = new SqlCommand("[dbo].[UpdateCars]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@Name", updatedCar.Name);
            command.Parameters.AddWithValue("@Registration", updatedCar.Registration);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return;
        }
    }
}
