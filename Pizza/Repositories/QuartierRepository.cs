using Microsoft.EntityFrameworkCore;
using Pizza.DbContexts;
using Pizza.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Repositories
{
    public class QuartierRepository : IQuartierRepository
    {
        private readonly PizzaDbContext _pizzaDbContext;

        public QuartierRepository(PizzaDbContext pizzaDbContext)
        {
            _pizzaDbContext = pizzaDbContext;
        }

        public async Task<IEnumerable<Num_Cde_Cli>> GetAllQuartiers()
        {
            return await _pizzaDbContext.Quartier.ToListAsync();
        }

        public async Task<Num_Cde_Cli> GetQuartierById(int id)
        {
            return await _pizzaDbContext.Quartier.Where(q => q.Num_Quartier == id).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateQuartier()
        {
            return await _pizzaDbContext.SaveChangesAsync();
        }

        public async Task<int> CreateQuartier(Num_Cde_Cli quartier)
        {
            await _pizzaDbContext.AddAsync(quartier);

            return await _pizzaDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteQuartiers(List<int> ids)
        {
            List<Num_Cde_Cli> quartiersToDelete = await _pizzaDbContext.Quartier.Where(q => ids.Contains(q.Num_Quartier)).ToListAsync();

            _pizzaDbContext.RemoveRange(quartiersToDelete);

            return await _pizzaDbContext.SaveChangesAsync();
        }
    }
}
