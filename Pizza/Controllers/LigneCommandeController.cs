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
    [Route("/lignescommandes")]
    [ApiController]
    public class LigneCommandeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILigneCommandeRepository _ligneCommandeRepository;

        public LigneCommandeController(IMapper mapper, ILigneCommandeRepository ligneCommandeRepository)
        {
            _mapper = mapper;
            _ligneCommandeRepository = ligneCommandeRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ligne_Cde_Cli>> GetLigneCommandeById(int id)
        {
            return Ok(await _ligneCommandeRepository.GetLigneCommandeById(id));
        }

        [HttpPut("{id}", Name = "GetLigneCommande")]
        public async Task<ActionResult> UpdateLigneCommandeById(int id, [FromBody] LigneCommandeForUpdateDto ligneCommandeDto)
        {
            Ligne_Cde_Cli ligneCommande = await _ligneCommandeRepository.GetLigneCommandeById(id);

            _mapper.Map(ligneCommandeDto, ligneCommande);

            await _ligneCommandeRepository.UpdateLigneCommande();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> CreateLigneCommande(LigneCommandeForCreateDto ligneCommandeDto)
        {
            Ligne_Cde_Cli ligneCommandeToCreate = _mapper.Map<Ligne_Cde_Cli>(ligneCommandeDto);

            await _ligneCommandeRepository.CreateLigneCommande(ligneCommandeToCreate);

            return CreatedAtRoute("GetLigneCommande", new
            {
                id = ligneCommandeToCreate.Num_Ligne_Cde
            }, ligneCommandeToCreate);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLigneCommande([FromBody] List<int> ids)
        {
            await _ligneCommandeRepository.DeleteLignesCommande(ids);

            return NoContent();
        }
    }
}
