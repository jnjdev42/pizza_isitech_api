using Pizza.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Repositories
{
    public interface ILivreurRepository
    {
        Task<int> DeleteLivreurs(List<int> ids);
        Task<int> CreateLivreur(Livreur livreur);
        Task<int> UpdateLivreur();
        Task<Livreur> GetLivreurById(int id);
        Task<IEnumerable<Livreur>> GetAllLivreurs();

    }
}
