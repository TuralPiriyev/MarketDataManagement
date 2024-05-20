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
    public class SqlBranchRepository : IBranchRepository
    {
        private readonly string _connectionString;
        public void Add(Branches branch)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Insert into Branches values(@name, @address)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("name",branch.Name);
            cmd.Parameters.AddWithValue("address",branch.Address);

            cmd.ExecuteNonQuery();
        }
        public void Update(Branches branch)
        {
            using  SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "Update branches set name = @name, address = @address";


            SqlCommand cmd = new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("id", branch.Id);
            cmd.Parameters.AddWithValue("name", branch.Name);
            cmd.Parameters.AddWithValue("address", branch.Address);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            const string query = "Delete from branches where id = @id";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("id", id);

            cmd.ExecuteNonQuery();
        }

        public Branches Get(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            const string query = "select * from branches where id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                return Mapper.BranchesMap(reader);
            }

            return null;

        }

        public List<Branches> Get()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);  
            connection.Open();
            const string query = "select * from branches";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Branches> result = new List<Branches>();
            while(reader.Read())
            {
                Branches branches = Mapper.BranchesMap(reader);
                result.Add(branches);
            }
            return result;

        }


    }
}
