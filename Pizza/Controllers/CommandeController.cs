using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.Entities;
using Pizza.Models;
using Pizza.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Controllers
{
    [Route("commandes")]
    [ApiController]
    public class CommandeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICommandeRepository _commandeRepository;

        public CommandeController(IMapper mapper, ICommandeRepository commandeRepository)
        {
            _mapper = mapper;
            _commandeRepository = commandeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CdeCli>>> GetAllCommandes()
        {
            return Ok(await _commandeRepository.GetAllCommandes());
        }

        [HttpGet("{id}", Name = "GetCommande")]
        public async Task<ActionResult<CdeCli>> GetCommandeById(int id)
        {
            return Ok(await _commandeRepository.GetCommandeById(id));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommandeById(int id, [FromBody] CommandeForUpdateDto commandeDto)
        {
            CdeCli commande = await _commandeRepository.GetCommandeById(id);

            _mapper.Map(commandeDto, commande);

            await _commandeRepository.UpdateCommande();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCommande(CommandeForCreateDto commandeDto)
        {
            CdeCli commandeToCreate = _mapper.Map<CdeCli>(commandeDto);

            await _commandeRepository.CreateCommande(commandeToCreate);

            return CreatedAtRoute("GetCommande", new
            {
                id = commandeToCreate.Num_Cde_Cli
            }, commandeToCreate);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCommandes([FromBody] List<int> ids)
        {
            await _commandeRepository.DeleteLignesCommandeFromCommmande(ids);

            await _commandeRepository.DeleteCommandes(ids);

            return NoContent();
        }
    }
}
