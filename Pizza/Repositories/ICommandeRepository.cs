using Pizza.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Repositories
{
    public interface ICommandeRepository
    {
        Task<IEnumerable<CdeCli>> GetAllCommandes();
        Task<CdeCli> GetCommandeById(int id);
        Task<int> UpdateCommande();
        Task<int> CreateCommande(CdeCli commande);
        Task<int> DeleteCommandes(List<int> ids);
        Task<int> DeleteLignesCommandeFromCommmande(List<int> commandeIds);
    }
}
