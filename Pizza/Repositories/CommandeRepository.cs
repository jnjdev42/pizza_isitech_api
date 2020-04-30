using Microsoft.EntityFrameworkCore;
using Pizza.DbContexts;
using Pizza.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Repositories
{
    public class CommandeRepository : ICommandeRepository
    {
        private readonly PizzaDbContext _pizzaDbContext;

        public CommandeRepository(PizzaDbContext pizzaDbContext)
        {
            _pizzaDbContext = pizzaDbContext;
        }
        public async Task<IEnumerable<CdeCli>> GetAllCommandes()
        {
            return await _pizzaDbContext.CdeCli
                .Include(c => c.Client)
                .ToListAsync();
        }

        public async Task<CdeCli> GetCommandeById(int id)
        {
            return await _pizzaDbContext.CdeCli
                .Where(c => c.Num_Cde_Cli == id)
                .Include(c => c.Client)
                .Include(c => c.Ligne_Cde_Clis).ThenInclude(l => l.Catalogue_Pizza)
                .FirstOrDefaultAsync();
        }

        public async Task<int> UpdateCommande()
        {
            return await _pizzaDbContext.SaveChangesAsync();
        }

        public async Task<int> CreateCommande(CdeCli commande)
        {
            await _pizzaDbContext.AddAsync(commande);

            return await _pizzaDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteCommandes(List<int> ids)
        {
            List<CdeCli> commandesToDelete = await _pizzaDbContext.CdeCli.Where(c => ids.Contains(c.Num_Cde_Cli)).ToListAsync();

            _pizzaDbContext.RemoveRange(commandesToDelete);

            return await _pizzaDbContext.SaveChangesAsync();
        }

        public async Task <int> DeleteLignesCommandeFromCommmande(List<int> commandeIds)
        {
            List<Ligne_Cde_Cli> lignesCommandesToDelete = await _pizzaDbContext.Ligne_Cde_Cli
                .Where(l => commandeIds.Contains(l.Num_Cde_Cli)).ToListAsync();

            _pizzaDbContext.RemoveRange(lignesCommandesToDelete);

            return await _pizzaDbContext.SaveChangesAsync();
        }
    }
}
