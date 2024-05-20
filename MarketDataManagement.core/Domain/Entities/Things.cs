using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataManagement.core.Domain.Entities
{
    public class Things
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string BarCode { get; set; }
        public byte Type { get; set; }
    }
}
