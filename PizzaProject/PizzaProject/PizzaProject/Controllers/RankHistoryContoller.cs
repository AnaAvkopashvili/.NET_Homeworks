using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.API.infrastructure.Localizations;
using PizzaRestaurant.API.infrastructure.Models.Examples;
using PizzaRestaurant.API.infrastructure.Models.Requests;
using PizzaRestaurant.Application.RankHistory;
using Swashbuckle.AspNetCore.Filters;


namespace PizzaRestaurant.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RankHistoryController : Controller
    {
        private readonly IRankHistoryService _service;
        public RankHistoryController(IRankHistoryService service)
        {
            _service = service;
        }
        /// <summary>
        /// Get  the whole rank history
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<RankHistoryResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAll(cancellationToken);
            return result;
        }
        /// <summary>
        /// Get rank by Id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(RankHistoryResponseModel))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, int id)
        {
            var result = await _service.Get(cancellationToken, id);

            if (result == null)
                return NotFound(ErrorMessages.RankHistoryNotFound);

            return Ok(result);
        }
        /// <summary>
        /// Create a new ranking
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Successfully addded a rank</response>
        /// <response code="400">If the rank is not valid</response>
        [SwaggerRequestExample(typeof(RankHistoryCreateModel), typeof(RankHistoryRequestExample))]
        [HttpPost]
        public async Task<IActionResult> Post(CancellationToken cancellationToken, RankHistoryCreateModel request)
        {
            var model = request.Adapt<RankHistoryResponseModel>();
            var result = await _service.Create(cancellationToken, model);
            if (!result)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            else
            {
                return Ok();
            }
        }
    }
}
