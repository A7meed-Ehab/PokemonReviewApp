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
    public class ReviewerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReviewerRepository _reviewerRepository;

        public ReviewerController(IMapper mapper,IReviewerRepository reviewerRepository)
        {
            this._mapper = mapper;
            this._reviewerRepository = reviewerRepository;
        }
        [HttpGet]
        [Route("list")]
        public IActionResult GetAll()
        {
            try
            {
                var reviewers = _reviewerRepository.GetReviewers();
                if (reviewers is null || reviewers.Any())
                {
                    return NotFound(new { Message = "No Reviewers Found!" });
                }
                var mappedReviewers = _mapper.Map<List<ReviewerDto>>(reviewers);
                return Ok(mappedReviewers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,new { Message = "An Error Occured While Retreiving Data",details=ex.Message });
            }
        }
        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int reviewerId)
        {
            if (!_reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();

            var reviewer = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewer(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }

        [HttpGet("{reviewerId}/reviews")]
        public IActionResult GetReviewsByAReviewer(int reviewerId)
        {
            if (!_reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();

            var reviews = _mapper.Map<List<ReviewDto>>(
                _reviewerRepository.GetReviewsByReviewer(reviewerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(ReviewerDto modelDto)
        {
            if (modelDto == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_reviewerRepository.Create(_mapper.Map<Reviewer>(modelDto)))
            {
                ModelState.AddModelError(string.Empty, "Couldn't Add Reviewer");
                return BadRequest(ModelState);
            }
            return Ok($"Added Successfully");
        }
    }
}
