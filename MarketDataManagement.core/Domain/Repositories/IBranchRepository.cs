using MarketDataManagement.core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketDataManagement.core.Domain.Repositories
{
    public interface IBranchRepository
    {
        void Add(Branches branch);
        void Update(Branches branch);
        void Delete(int id);

        Branches Get(int id);
        List<Branches> Get();
    }
}
