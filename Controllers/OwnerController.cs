using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Modles;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        private readonly IOwnerRepository _ownerRepository;

        public OwnerController(IMapper mapper,ICountryRepository countryRepository, IOwnerRepository ownerRepository)
        {
            this._mapper = mapper;
            this._countryRepository = countryRepository;
            this._ownerRepository = ownerRepository;
        }
        //ICollection<Pokemon> GetPokemonsByOwner(int id);
        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OwnerDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var owners = _ownerRepository.GetOwners();
                if (owners == null || !owners.Any())
                {
                    return NotFound(new { message = "No owners found." });
                }
                var mappedOwners = _mapper.Map<List<OwnerDto>>(owners);
                return Ok(mappedOwners);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "An error occurred while retrieving owners.", details = ex.Message });
            }
        }
        [HttpGet("Owner")]
        public IActionResult GetById(int id)
        {
            try
            {
                var owner = _ownerRepository.GetOwner(id);
                if (owner == null)
                {
                    return NotFound(new { message = "No User Found" });
                }
                var mappedOwner = _mapper.Map<OwnerDto>(owner);
                return Ok(mappedOwner);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An Error Occured", detials = ex.Message });
            }
        }
        [HttpGet("OwnerByPokemon")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OwnerDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetOwnerByPokemon(int id)
        {
            try
            {
                var owners = _ownerRepository.GetOwnersByPokemon(id);
                if (owners == null || !owners.Any())
                {
                    return NotFound(new { message = "No owners found." });
                }
                var mappedOwners = _mapper.Map<List<OwnerDto>>(owners);
                return Ok(mappedOwners);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "An error occurred while retrieving owners.", details = ex.Message });
            }
        }
        [HttpGet("PokemonByOwner")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PokemonDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetPokemonsByOwner(int id)
        {
            try
            {
                var pokemons = _ownerRepository.GetPokemonsByOwner(id);
                if (pokemons == null || !pokemons.Any())
                {
                    return NotFound(new { message = "No owners found." });
                }
                var mappedPokemons = _mapper.Map<List<PokemonDto>>(pokemons);
                return Ok(mappedPokemons);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "An error occurred while retrieving owners.", details = ex.Message });
            }
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromQuery] int CountryId,[FromBody]OwnerDto ownerDto)
        {
            if(ownerDto == null)
            {
                return BadRequest();
            }

            var owners = _ownerRepository.GetOwners()
                .Where(o => o.LastName.Trim().ToLower()==ownerDto.LastName.Trim().ToLower())
                .ToList();
            if (owners.Any())
            {
                ModelState.AddModelError(string.Empty, "Owner Already Exists");
                return StatusCode(422,ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mappedOwner = _mapper.Map<Owner>(ownerDto);
            mappedOwner.Country=_countryRepository.GetById(CountryId);
            if (!_ownerRepository.Create(mappedOwner)){
                ModelState.AddModelError(string.Empty, "Couldn't Add Owner");
                return StatusCode(500,ModelState);
            };
            return Ok($"Added New Owener {mappedOwner.FirstName} {mappedOwner.LastName}");
        }
        [HttpPut]
        public IActionResult Update(int countryId,int ownerId,[FromBody] OwnerDto ownerDto)
        {
            if (ownerDto == null || ownerId!=ownerDto.Id)
            {
                return BadRequest(ModelState);
            }
            if (_ownerRepository.GetOwner(ownerId)==null)
            {
                return NotFound();
            }
            var mappedModel= _mapper.Map<Owner>(ownerDto);
            mappedModel.Country = _countryRepository.GetById(countryId);
            if (!_ownerRepository.Update(mappedModel))
            {
                ModelState.AddModelError(string.Empty, "couldn't Update the Owener");
                return StatusCode(500,ModelState);
            }
            return NoContent();
        }
    } 
}
