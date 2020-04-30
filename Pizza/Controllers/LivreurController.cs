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
    [Route("livreurs")]
    [ApiController]
    public class LivreurController : Controller
    {
        private readonly ILivreurRepository _livreurRepository;
        private readonly IMapper _mapper;

        public LivreurController(ILivreurRepository livreurRepository, IMapper mapper)
        {
            _livreurRepository = livreurRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livreur>>> GetAllLivreurs()
        {
            return Ok(await _livreurRepository.GetAllLivreurs());
        }

        [HttpGet("{id}", Name = "GetLivreur")]
        public async Task<ActionResult<Livreur>> GetLivreurById(int id)
        {
            return Ok(await _livreurRepository.GetLivreurById(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLivreurById(int id, [FromBody] LivreurForUpdateDto livreurDto)
        {
            Livreur livreur = await _livreurRepository.GetLivreurById(id);

            _mapper.Map(livreurDto, livreur);

            await _livreurRepository.UpdateLivreur();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> CreateLivreur(LivreurForCreateDto livreurDto)
        {
            Livreur livreurToCreate = _mapper.Map<Livreur>(livreurDto);

            await _livreurRepository.CreateLivreur(livreurToCreate);

            return CreatedAtRoute("GetLivreur", new
            {
                id = livreurToCreate.Num_Liv
            }, livreurToCreate);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLivreurs([FromBody] List<int> ids)
        {
            await _livreurRepository.DeleteLivreurs(ids);

            return NoContent();
        }
    }
}
