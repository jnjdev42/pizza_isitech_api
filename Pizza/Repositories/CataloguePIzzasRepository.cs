using Microsoft.EntityFrameworkCore;
using Pizza.DbContexts;
using Pizza.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Repositories
{
    public class CataloguePIzzasRepository : ICataloguePizzasRepository
    {
        private readonly PizzaDbContext _pizzaDbContext;

        public CataloguePIzzasRepository(PizzaDbContext pizzaDbContext)
        {
            _pizzaDbContext = pizzaDbContext;
        }

        public async Task<IEnumerable<Catalogue_Pizza>> GetAllPizzas()
        {
            return await _pizzaDbContext.Catalogue_Pizza.ToListAsync();
        }

        public async Task<Catalogue_Pizza> GetPizzaById(int id)
        {
            return await _pizzaDbContext.Catalogue_Pizza.Where(p => p.Num_Pizza == id).FirstOrDefaultAsync();
        }

        public async Task<int> UpdatePizza()
        {
            return await _pizzaDbContext.SaveChangesAsync();
        }

        public async Task<int> CreatePizza(Catalogue_Pizza pizza)
        {
            await _pizzaDbContext.AddAsync(pizza);

            return await _pizzaDbContext.SaveChangesAsync();
        }

        public async Task<int> DeletePizzas(List<int> ids)
        {
            List<Catalogue_Pizza> pizzasToDelete = await _pizzaDbContext.Catalogue_Pizza.Where(p => ids.Contains(p.Num_Pizza)).ToListAsync();

            _pizzaDbContext.RemoveRange(pizzasToDelete);

            return await _pizzaDbContext.SaveChangesAsync();
        }
    }
}
