using Pizza.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Repositories
{
    public interface ILigneCommandeRepository
    {
        Task<Ligne_Cde_Cli> GetLigneCommandeById(int id);
        Task<int> UpdateLigneCommande();
        Task<int> CreateLigneCommande(Ligne_Cde_Cli ligneCommande);
        Task<int> DeleteLignesCommande(List<int> ids);
    }
}
