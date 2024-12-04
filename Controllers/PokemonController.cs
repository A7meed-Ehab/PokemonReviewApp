using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Data;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Modles;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IMapper mapper,IPokemonRepository pokemonRepository)
        {
            this._mapper = mapper;
            this._pokemonRepository = pokemonRepository;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PokemonDto>))]
        public IActionResult GetPokemons()
        {
            var MappedPokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(MappedPokemons);
        }
        [HttpGet("GetPokemonRate")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult GetPokemonRate(int id)
        {
            if (!_pokemonRepository.PkemonExists(id))
            {
                return NotFound();
            }
            var rate = _pokemonRepository.GetPokemonRating(id);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(rate);

        }
    }
}
