using MarketDataManagement.core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataManagement.core.DataAccessLayer
{
    public static class Mapper
    {
        public static Branches BranchesMap(IDataReader reader)
        {
            return new Branches
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Address = (string)reader["Address"]
            };
        }

        public static Food FoodMap(IDataReader reader)
        {
            return new Food
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Price = (decimal)reader["price"],
                Stock = (int)reader["stock"],
                ExplorationDate = (string)reader["ExplorationDate"],
                Barcode = (string)reader["BarCode"],
                Type = (byte)reader["Type"]

            };
        }

        public static Things ThingsMap(IDataReader reader)
        {
            return new Things
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Price = (decimal)reader["Price"],
                BarCode = (string)reader["BarCode"],
                Type = (byte)reader["Type"]

            };
        }
    }
}
