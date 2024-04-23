using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.Application.Pizza;
using PizzaRestaurant.API.infrastructure.Localizations;
using PizzaRestaurant.API.infrastructure.Models.DTO;
using PizzaRestaurant.API.infrastructure.Models.Requests;
using PizzaRestaurant.API.infrastructure.Models.Examples;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : Controller
    {
        private readonly IPizzaService _service;

        public PizzaController(IPizzaService service)
        {
            _service = service;
        }
        /// <summary>
        /// Get all pizzas
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<PizzaDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAll(cancellationToken);
            var dtoResult = result.Adapt<List<PizzaDTO>>();
            return dtoResult;
        }
        /// <summary>
        /// Get one pizza by id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PizzaDtoExample))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, int id)
        {
            var result = await _service.Get(cancellationToken, id);

            if (result == null)
                return NotFound(ErrorMessages.PizzaNotFound);

            return Ok(result.Adapt<PizzaDTO>());
        }
        /// <summary>
        /// Post a new pizza
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        ///  <response code="200">Successfully addded a pizza</response>
        /// <response code="400">If the pizza is not valid</response>
        [SwaggerRequestExample(typeof(PizzaCreateModel), typeof(PizzaRequestExample))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post(CancellationToken cancellationToken, PizzaCreateModel request)
        {
            var model = request.Adapt<PizzaRequestModel>();
            var result = _service.Create(cancellationToken, model);
            if (result == null)
            {
                return BadRequest(ErrorMessages.PizzaAlreadyExists);
            }
            return Ok();
        }
        /// <summary>
        /// Update a pizza
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPut] 
        public async Task Put(CancellationToken cancellationToken, PizzaPutModel request)
        {
            var model = request.Adapt<PizzaRequestModel>();

            await _service.Update(cancellationToken, model);
        }
        /// <summary>
        /// Delete a pizza
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(CancellationToken cancellationToken, int id)
        {
            await _service.Delete(cancellationToken, id);
        }
    }
}
