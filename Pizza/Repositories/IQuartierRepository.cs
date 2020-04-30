using Pizza.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Repositories
{
    public interface IQuartierRepository
    {
        Task<IEnumerable<Num_Cde_Cli>> GetAllQuartiers();
        Task<Num_Cde_Cli> GetQuartierById(int id);
        Task<int> UpdateQuartier();
        Task<int> CreateQuartier(Num_Cde_Cli quartier);
        Task<int> DeleteQuartiers(List<int> ids);
    }
}
