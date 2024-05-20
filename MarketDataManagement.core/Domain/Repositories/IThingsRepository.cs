using MarketDataManagement.core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataManagement.core.Domain.Repositories
{
    public interface IThingsRepository
    {
        public void Add(Things things);
        public void Update(Things things);
        public void Delete(int id);

        Things Get(int id);
        List<Things> Get();

    }
}
