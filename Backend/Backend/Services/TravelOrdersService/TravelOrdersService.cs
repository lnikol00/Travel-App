using Backend.Models;
using Backend.Services.TravelOrdersService.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Backend.Services.TravelOrdersService
{
    public class TravelOrdersService : ITravelOrdersService
    {
        private readonly string _connectionDB;
        private readonly string _dbDatetimeFormat = "yyyy-MM-dd";
        public TravelOrdersService(IOptions<DBConfiguration> configuration)
        {
            _connectionDB = configuration.Value.ConnectionDB;
        }

        // Create new Travel Order
        public void CreateTravelOrder(TravelOrders travelOrder)
        {
            using var connection = new SqlConnection(_connectionDB);
            using var command = new SqlCommand("[dbo].[CreateTravelOrders]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@EmployeeID", travelOrder.EmployeeId);
            command.Parameters.AddWithValue("@CarsID", travelOrder.CarsId);
            command.Parameters.AddWithValue("@Date", travelOrder.Date.ToString(_dbDatetimeFormat));
            command.Parameters.AddWithValue("@Mileage", travelOrder.Mileage);
            command.Parameters.AddWithValue("@Route", travelOrder.Route);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return;
        }

        // Get All Travel Orders
        public List<TravelOrders> GetTravelOrders()
        {
            using var connection = new SqlConnection(_connectionDB);
            using var command = new SqlCommand("[dbo].[GetAllTravelOrders]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            connection.Open();
            using var reader = command.ExecuteReader();

            var lstTravelOrders = new List<TravelOrders>();

            while (reader.Read())
            {
                {
                    var travelOrder = new TravelOrders
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Brand = reader.GetString(3),
                        Registration = reader.GetString(4),
                        Date = DateTime.ParseExact(reader.GetString(5), _dbDatetimeFormat, null),
                        Mileage = reader.GetInt32(6),
                        Route = reader.GetString(7),
                        EmployeeId = reader.GetInt32(8),
                        CarsId = reader.GetInt32(9)
                    };

                    lstTravelOrders.Add(travelOrder);
                }
            }

            connection.Close();
            return lstTravelOrders;
        }

        // GET BY ID 
        public TravelOrders? GetTravelOrderByID(int id)
        {
            using var connection = new SqlConnection(_connectionDB);
            using var command = new SqlCommand("[dbo].[GetTravelOrderById]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using var reader = command.ExecuteReader();

            TravelOrders travelOrders = null;

            if (reader.Read())
            {
                travelOrders = new TravelOrders
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Brand = reader.GetString(3),
                    Registration = reader.GetString(4),
                    Date = DateTime.ParseExact(reader.GetString(5), _dbDatetimeFormat, null),
                    Mileage = reader.GetInt32(6),
                    Route = reader.GetString(7),
                    EmployeeId = reader.GetInt32(8),
                    CarsId = reader.GetInt32(9)
                };
            }
            connection.Close();
            return travelOrders;
        }

        // Delete Travel Order
        public void DeleteTravelOrder(int id)
        {
            using var connection = new SqlConnection(_connectionDB);
            using var command = new SqlCommand("[dbo].[DeleteTravelOrders]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                throw new ArgumentException($"No travel order with ID = {id}.");
            }

            connection.Close();
        }

        // Update Travel Order
        public void UpdateTravelOrder(int id, TravelOrders updatedTravelOrder)
        {
            using var connection = new SqlConnection(_connectionDB);
            using var command = new SqlCommand("[dbo].[UpdateTravelOrders]", connection);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@EmployeeID", updatedTravelOrder.EmployeeId);
            command.Parameters.AddWithValue("@CarsID", updatedTravelOrder.CarsId);
            command.Parameters.AddWithValue("@Date", updatedTravelOrder.Date.ToString(_dbDatetimeFormat));
            command.Parameters.AddWithValue("@Mileage", updatedTravelOrder.Mileage);
            command.Parameters.AddWithValue("@Route", updatedTravelOrder.Route);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return;
        }
    }
}
