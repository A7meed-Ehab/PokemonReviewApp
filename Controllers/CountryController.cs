using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Modles;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public CountryController(IMapper mapper, ICountryRepository countryRepository)
        {
            this._mapper = mapper;
            this._countryRepository = countryRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        [HttpGet("List")]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(countries);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId))
                return NotFound();

            var country = _mapper.Map<CountryDto>(_countryRepository.GetById(countryId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }

        [HttpGet("CountryOfOwner/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetCountryOfAnOwner(int ownerId)
        {
            var country = _mapper.Map<CountryDto>(
                _countryRepository.GetCountryByOwner(ownerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(country);
        }
        [HttpGet("GetOwnersByCountry/{id}")]
        public IActionResult GetAllOwners(int id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid id Range");
            }
            var owners = _countryRepository.GetOwnersFromCountry(id);
            if (!owners.Any())
            {
                return BadRequest("No Owners Found");
            }
            var MappedOwners = _mapper.Map<List<OwnerDto>>(owners);
            return Ok(MappedOwners);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(CountryDto modelDto)
        {
            if (modelDto == null)
            {
                return BadRequest(ModelState);
            }
            var model = _countryRepository.GetByName(modelDto.Name);
            if (model != null)
            {
                ModelState.AddModelError(string.Empty, "Country Already Exists");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_countryRepository.Create(_mapper.Map<Country>(modelDto)))
            {
                ModelState.AddModelError(string.Empty, "Couldn't Add Country");
                return BadRequest(ModelState);
            }
            return Ok($"Added {modelDto.Name} Successfully");
        }
        [HttpPut]
        public IActionResult Update(int countryId, CountryDto modelDto)
        {
            if (modelDto == null || countryId != modelDto.Id)
            {
                return BadRequest(ModelState);
            }
            if (!_countryRepository.CountryExists(countryId))
            {
                return NotFound();
            }
            var mappedModel=_mapper.Map<Country>(modelDto);
            if(!_countryRepository.Update(mappedModel))
            {
                ModelState.AddModelError(string.Empty, "Couldn't Add Model");
                return StatusCode(500,ModelState);
            }
            return NoContent();
        }
    }

}