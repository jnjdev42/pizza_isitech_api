using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.Entities;
using Pizza.Models;
using Pizza.Profiles;
using Pizza.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Controllers
{
    [Route("pizzas")]
    [ApiController]
    public class CataloguePizzaController : Controller
    {
        private readonly ICataloguePizzasRepository _pizzaRepository;
        private readonly IMapper _mapper;

        public CataloguePizzaController(ICataloguePizzasRepository cataloguePizzaRepository, IMapper mapper)
        {
            _pizzaRepository = cataloguePizzaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalogue_Pizza>>> GetAllPizzas()
        {
            return Ok(await _pizzaRepository.GetAllPizzas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Catalogue_Pizza>> GetPizzaById(int id)
        {
            return Ok(await _pizzaRepository.GetPizzaById(id));
        }

        [HttpPut("{id}", Name = "GetPizza")]
        public async Task<ActionResult> UpdatePizzaById(int id, [FromBody] CataloguePizzaForUpdateDto pizzaDto)
        {
            Catalogue_Pizza pizza = await _pizzaRepository.GetPizzaById(id);

            _mapper.Map(pizzaDto, pizza);

            await _pizzaRepository.UpdatePizza();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePizza(CataloguePizzaForCreateDto pizzaDto)
        {
            Catalogue_Pizza pizzaToCreate = _mapper.Map<Catalogue_Pizza>(pizzaDto);

            await _pizzaRepository.CreatePizza(pizzaToCreate);

            return CreatedAtRoute("GetPizza", new
            {
                id = pizzaToCreate.Num_Pizza
            }, pizzaToCreate);
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePizzas([FromBody] List<int> ids)
        {

            await _pizzaRepository.DeletePizzas(ids);

            return NoContent();
        }
    }
}
