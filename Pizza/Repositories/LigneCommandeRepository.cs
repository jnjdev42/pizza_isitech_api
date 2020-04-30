using Microsoft.EntityFrameworkCore;
using Pizza.DbContexts;
using Pizza.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Repositories
{
    public class LigneCommandeRepository : ILigneCommandeRepository
    {
        private readonly PizzaDbContext _pizzaDbContext;

        public LigneCommandeRepository(PizzaDbContext pizzaDbContext)
        {
            _pizzaDbContext = pizzaDbContext;
        }

        public async Task<Ligne_Cde_Cli> GetLigneCommandeById(int id)
        {
            return await _pizzaDbContext.Ligne_Cde_Cli.Where(l => l.Num_Ligne_Cde == id).Include(l => l.Catalogue_Pizza).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateLigneCommande()
        {
            return await _pizzaDbContext.SaveChangesAsync();
        }

        public async Task<int> CreateLigneCommande(Ligne_Cde_Cli ligneCommande)
        {
            await _pizzaDbContext.AddAsync(ligneCommande);

            return await _pizzaDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteLignesCommande(List<int> ids)
        {
            List<Ligne_Cde_Cli> lignesCommandeToDelete = await _pizzaDbContext.Ligne_Cde_Cli.Where(l => ids.Contains(l.Num_Ligne_Cde)).ToListAsync();

            _pizzaDbContext.RemoveRange(lignesCommandeToDelete);

            return await _pizzaDbContext.SaveChangesAsync();
        }

    }
}
