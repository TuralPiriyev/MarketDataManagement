using MarketDataManagement.core.Domain.Entities;
using MarketDataManagement.core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataManagement.core.DataAccessLayer.SqlServer
{
    public class SqlFoodRepository : IFoodRepository
    {
        private readonly string _connectionString;

        public SqlFoodRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Food food)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Insert into foods values(@name,@price,@stock,explorationdate,@barcode,@type";

            SqlCommand cmd = new SqlCommand(query, connection);
            
            cmd.Parameters.AddWithValue("Name", food.Name);
            cmd.Parameters.AddWithValue("Price", food.Price);
            cmd.Parameters.AddWithValue("stock", food.Stock);
            cmd.Parameters.AddWithValue("explorationdate", food.ExplorationDate);
            cmd.Parameters.AddWithValue("barcode", food.Barcode);
            cmd.Parameters.AddWithValue("Type", food.Type);

            cmd.ExecuteNonQuery();
        }
        public void Update(Food food)
        {
           using SqlConnection connection = new SqlConnection( _connectionString);
            connection.Open();
            const string query = "update food set name = @name, price=@price, stock = @stock, explorationdate= @explorationdate, barcode=@barcode, type=@type ";
            SqlCommand cmd = new SqlCommand(_connectionString, connection);
            cmd.Parameters.AddWithValue("id", food.Id);
            cmd.Parameters.AddWithValue("Name", food.Name);
            cmd.Parameters.AddWithValue("Price", food.Price);
            cmd.Parameters.AddWithValue("stock", food.Stock);
            cmd.Parameters.AddWithValue("explorationdate", food.ExplorationDate);
            cmd.Parameters.AddWithValue("barcode", food.Barcode);
            cmd.Parameters.AddWithValue("Type", food.Type);

            cmd.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection( _connectionString);
            connection.Open();
            const string query = "delete from food where id=@id";
            SqlCommand cmd = new SqlCommand(_connectionString, connection);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }

        public Food Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = "select * from food where id=@id";
            SqlCommand cmd = new SqlCommand(_connectionString, connection);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return Mapper.FoodMap(reader);
            }
            return null;


        }

        public List<Food> Get()
        {
            using SqlConnection connection = new SqlConnection();
            connection.Open();
            const string query = "select * from food";

            SqlCommand cmd = new SqlCommand(_connectionString, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Food> result = new List<Food>();
            while(reader.Read())
                {
                   Food food =  Mapper.FoodMap(reader);
                    result.Add(food);
                }
            return result;
        }

        
    }
}
