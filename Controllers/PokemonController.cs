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
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PokemonController(IMapper mapper,IPokemonRepository pokemonRepository,IOwnerRepository ownerRepository,ICategoryRepository categoryRepository)
        {
            this._mapper = mapper;
            this._pokemonRepository = pokemonRepository;
            this._ownerRepository = ownerRepository;
            this._categoryRepository = categoryRepository;
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
        [HttpPost]
        [Route("Create")]
        public IActionResult CreatePokemon([FromQuery]int categoryId,[FromQuery]int ownerId,[FromBody]PokemonDto modelDto)
        {
            if(modelDto == null)
            {
                return BadRequest();
            }
             var getPokemon=_pokemonRepository.GetPokemon(modelDto.Name);
            if (getPokemon != null)
            {
                ModelState.AddModelError(string.Empty, "Pokemon Already Exists!");
                return StatusCode(422,ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var mappedModel = _mapper.Map<Pokemon>(modelDto);
            if (!_pokemonRepository.Create(categoryId, ownerId, mappedModel))
            {
                ModelState.AddModelError(string.Empty, "Failed to Add Model");
                return StatusCode(500, ModelState); 
            }
            return Ok($"Added {mappedModel.Name} Successfully");
        }
        [HttpPut]
        public IActionResult UpdatePokemon(int pokeId,
          [FromQuery] int catId,
          [FromQuery] string catName,
          [FromBody] PokemonDto updatedPokemon)
        {
            if (updatedPokemon == null)
                return BadRequest(ModelState);

            if (pokeId != updatedPokemon.Id)
                return BadRequest(ModelState);

            if (_pokemonRepository.GetPokemon(pokeId)==null)
                return NotFound();
            var pokemonMap = _mapper.Map<Pokemon>(updatedPokemon);
            if (!_pokemonRepository.Update(catId, catName, pokemonMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
