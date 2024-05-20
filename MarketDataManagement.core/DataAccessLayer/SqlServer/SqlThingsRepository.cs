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
    public class SqlThingsRepository : IThingsRepository
    {
        private readonly string _connectionString;

        public SqlThingsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Things things)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Insert into things values(name = @name, price = @price, barcode = @barcode, type=@type";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("name", things.Name);
            cmd.Parameters.AddWithValue("Price", things.Price);
            cmd.Parameters.AddWithValue("BarCode",things.BarCode);
            cmd.Parameters.AddWithValue("Type",things.Type);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "delete from things where id=@id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery ();
        }
        public void Update(Things things)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "update things set name = @name, price = @price, barcode = @barcode,type = @type";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("name", things.Name);
            cmd.Parameters.AddWithValue("Price",things.Price);
            cmd.Parameters.AddWithValue("barcode",things.BarCode);
            cmd.Parameters.AddWithValue("type", things.Type);
            cmd.ExecuteNonQuery ();
        }

        public Things Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Select * from things wehre id=@id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue ("id", id);

            SqlDataReader reader = cmd.ExecuteReader ();

            if(reader.Read ())
            {
                return Mapper.ThingsMap(reader);
            }
            return null;
            
        }

        public List<Things> Get()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from things";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Things> result = new List<Things>();
            while (reader.Read ())
            { 
                Things things = Mapper.ThingsMap(reader);

                return result;
            }
            return null;

        }

       
    }
}
