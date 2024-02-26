using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.API.infrastructure.Localizations;
using PizzaRestaurant.API.infrastructure.Models.Examples;
using PizzaRestaurant.API.infrastructure.Models.Requests;
using PizzaRestaurant.Application.Order;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }
        /// <summary>
        /// Get all Orders
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<OrderResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAll(cancellationToken);
            return result;
        }
        /// <summary>
        /// Get order by Id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(OrderResponseModel))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, int id)
        {
            var result = await _service.Get(cancellationToken, id);

            if (result == null)
                return NotFound(ErrorMessages.OrderNotFound);

            return Ok(result);
        }
        /// <summary>
        /// Create a new order
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        ///  <response code="200">Successfully addded a Order</response>
        /// <response code="400">If the order is not valid</response>
        [SwaggerRequestExample(typeof(OrderCreateModel), typeof(OrderRequestExample))]
        [HttpPost]
        public async Task<IActionResult> Post(CancellationToken cancellationToken, OrderCreateModel request)
        {
            var model = request.Adapt<OrderResponseModel>();
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
