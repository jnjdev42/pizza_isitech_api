using Microsoft.EntityFrameworkCore;
using Pizza.DbContexts;
using Pizza.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Repositories
{
    public class LivreurRepository : ILivreurRepository
    {
        private readonly PizzaDbContext _pizzaDbContext;

        public LivreurRepository(PizzaDbContext pizzaDbContext)
        {
            _pizzaDbContext = pizzaDbContext;
        }

        public async Task<IEnumerable<Livreur>> GetAllLivreurs()
        {
            return await _pizzaDbContext.Livreur.Include(l => l.Quartier).ToListAsync();
        }

        public async Task<Livreur> GetLivreurById(int id)
        {
            return await _pizzaDbContext.Livreur.Where(p => p.Num_Liv == id).Include(l => l.Quartier).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateLivreur()
        {
            return await _pizzaDbContext.SaveChangesAsync();
        }

        public async Task<int> CreateLivreur(Livreur livreur)
        {
            await _pizzaDbContext.AddAsync(livreur);

            return await _pizzaDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteLivreurs(List<int> ids)
        {
            List<Livreur> livreursToDelete = await _pizzaDbContext.Livreur.Where(l => ids.Contains(l.Num_Liv)).ToListAsync();

            _pizzaDbContext.RemoveRange(livreursToDelete);

            return await _pizzaDbContext.SaveChangesAsync();
        }
    }
}
