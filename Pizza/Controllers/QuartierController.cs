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
    [Route("quartiers")]
    [ApiController]
    public class QuartierController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IQuartierRepository _quartierRepository;

        public QuartierController(IMapper mapper, IQuartierRepository quartierRepository)
        {
            _mapper = mapper;
            _quartierRepository = quartierRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Num_Cde_Cli>>> GetAllQuartiers()
        {
            return Ok(await _quartierRepository.GetAllQuartiers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Num_Cde_Cli>> GetQuartierById(int id)
        {
            return Ok(await _quartierRepository.GetQuartierById(id));
        }

        [HttpPut("{id}", Name = "GetQuartier")]
        public async Task<ActionResult> UpdateQuartierById(int id, [FromBody] QuartierForUpdateDto quartierDto)
        {
            Num_Cde_Cli quartier = await _quartierRepository.GetQuartierById(id);

            _mapper.Map(quartierDto, quartier);

            await _quartierRepository.UpdateQuartier();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> CreateQuartier(QuartierForCreateDto quartierDto)
        {
            Num_Cde_Cli quartierToCreate = _mapper.Map<Num_Cde_Cli>(quartierDto);

            await _quartierRepository.CreateQuartier(quartierToCreate);

            return CreatedAtRoute("GetQuartier", new
            {
                id = quartierToCreate.Num_Quartier
            }, quartierToCreate);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteQuartiers([FromBody] List<int> ids)
        {
            await _quartierRepository.DeleteQuartiers(ids);

            return NoContent();
        }
    }
}
