using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.API.infrastructure.Localizations;
using PizzaRestaurant.API.infrastructure.Models.DTO;
using PizzaRestaurant.API.infrastructure.Models.Requests;
using Mapster;
using PizzaRestaurant.Application.Address;
using PizzaRestaurant.API.infrastructure.Models.Examples;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }
        /// <summary>
        /// Get all addresses
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<AddressDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAll(cancellationToken);
            var dtoResult = result.Adapt<List<AddressDTO>>();
            return dtoResult;
        }
        /// <summary>
        /// Get an address by id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AddressDtoExample))]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken, int id)
        {
            var result = await _service.Get(cancellationToken, id);

            if (result == null)
                return NotFound(ErrorMessages.AddressNotFound);

            return Ok(result.Adapt<AddressDTO>());
        }
        /// <summary>
        /// Create a new address
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// ///  <response code="200">Successfully addded a address</response>
        /// <response code="400">If the address is not valid</response>
        [SwaggerRequestExample(typeof(AddressCreateModel), typeof(AddressRequestExample))]
        [HttpPost]
        public async Task Post(CancellationToken cancellationToken, AddressCreateModel request)
        {
            var model = request.Adapt<AddressRequestModel>();

            await _service.Create(cancellationToken, model);
        }
        /// <summary>
        /// Update an address
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Put(CancellationToken cancellationToken, AddressPutModel request)
        {
            var model = request.Adapt<AddressRequestModel>();

            await _service.Update(cancellationToken, model);
        }
        /// <summary>
        /// Delete an address
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
