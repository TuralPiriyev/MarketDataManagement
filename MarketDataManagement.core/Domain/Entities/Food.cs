using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataManagement.core.Domain.Entities
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }  
        public int Stock { get; set; }
        public  string ExplorationDate { get; set; }
        public string Barcode { get; set; }
        public byte Type { get; set; }
    }
}
