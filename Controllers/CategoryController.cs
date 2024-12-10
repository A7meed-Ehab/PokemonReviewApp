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
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(IMapper mapper, ICategoryRepository categoryRepository)
        {
            this._mapper = mapper;
            this._categoryRepository = categoryRepository;
        }
        [HttpGet("all")]
        public IActionResult GetAllCategories()
        {

            var mappedCategories = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mappedCategories);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCategory(int id)
        {
            var MappedCategory = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(MappedCategory);
        }

        [HttpGet("pokemon/{id}")]
        [ProducesResponseType(typeof(IEnumerable<PokemonDto>), 200)]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategories(int id)
        {
            if (id == 0)
            {
                return BadRequest("id Out Of Range");
            }
            var pokemons = _categoryRepository.GetPokemonByCategory(id);
            if (pokemons is null || pokemons.Count == 0)
            {
                return BadRequest("No Result Found!");
            }
            var MappedPokemont = _mapper.Map<List<PokemonDto>>(pokemons);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(MappedPokemont);

        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(CategoryDto modelDto)
        {
            if (modelDto == null)
            {
                return BadRequest(ModelState);

            }
            //var category = _categoryRepository.GetCategories().Where(c => c.Name.Trim().ToLower() == modelDto.Name.TrimEnd().ToLower()).FirstOrDefault();
            var mappedCategory=_mapper.Map<Category>(modelDto);
            var checkExists = _categoryRepository.CategoriesExists(mappedCategory.Name);
           if (checkExists != null)
            {
                ModelState.AddModelError(string.Empty, "Category Already Exists");
                return StatusCode(422,ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_categoryRepository.Create(mappedCategory))
            {
                ModelState.AddModelError(string.Empty, $"Faild To Add Category {mappedCategory.Name}");
                return StatusCode(500,ModelState);
            }
            return Ok("Category Added Successfuly");
        }
        [HttpPut]
        public IActionResult UpdateCategory(int categoryId,CategoryDto categoryDto)
        {
            if(categoryDto == null)
            {
                return BadRequest(ModelState);
            }
            if(categoryId != categoryDto.Id)
            {
                return BadRequest(ModelState);
            }
            if (!_categoryRepository.CategoriesExists(categoryDto.Id))
            {
                return NotFound();
            }
            var mappedCategory = _mapper.Map<Category>(categoryDto);
            if (!_categoryRepository.UpdateCategory(mappedCategory))
            {
                ModelState.AddModelError(string.Empty, "Something went Werong updating Category");
                return StatusCode(500,ModelState);
            }
            return NoContent();

        }
    }
}
