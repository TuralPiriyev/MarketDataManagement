using MarketDataManagement.core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataManagement.core.Domain.Repositories
{
    public interface IFoodRepository
    {
        void Add(Food food);
        void Update(Food food);
        void Delete(int id);
       
        Food Get(int id);
        List<Food> Get();
    }
}
