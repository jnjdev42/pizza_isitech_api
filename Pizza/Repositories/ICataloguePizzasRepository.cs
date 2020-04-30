using Pizza.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Repositories
{
    public interface ICataloguePizzasRepository
    {
        Task<IEnumerable<Catalogue_Pizza>> GetAllPizzas();
        Task<Catalogue_Pizza> GetPizzaById(int id);
        Task<int> UpdatePizza();
        Task<int> CreatePizza(Catalogue_Pizza pizza);
        Task<int> DeletePizzas(List<int> ids);
    }
}
