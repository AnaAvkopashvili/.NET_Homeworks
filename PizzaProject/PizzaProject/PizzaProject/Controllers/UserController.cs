using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.API.infrastructure.Localizations;
using PizzaRestaurant.API.infrastructure.Models.DTO;
using PizzaRestaurant.API.infrastructure.Models.Examples;
using PizzaRestaurant.API.infrastructure.Models.Requests;
using PizzaRestaurant.Application.User;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        /// <summary>
        /// Get all Users
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<UserDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAll(cancellationToken);
            var dtoResult = result.Adapt<List<UserDTO>>();
            return dtoResult;
        }
        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// [Produces("application/json")]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserDtoExample))]
        [HttpGet("{id}")]

        public async Task<IActionResult> Get(CancellationToken cancellationToken, int id)
        {
            var result = await _service.Get(cancellationToken, id);

            if (result == null)
                return NotFound(ErrorMessages.UserNotFound);

            return Ok(result.Adapt<UserDTO>());
        }
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        ///  <response code="200">Successfully addded a user</response>
         /// <response code="400">If the user is not valid</response>
        [SwaggerRequestExample(typeof(UserCreateModel), typeof(UserRequestExample))]
        [HttpPost]
        public async Task Post(CancellationToken cancellationToken, UserCreateModel request)
        {
            var model = request.Adapt<UserRequestModel>();

            await _service.Create(cancellationToken, model);
        }
        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Put(CancellationToken cancellationToken, UserPutModel request)
        {
            var model = request.Adapt<UserRequestModel>();

            await _service.Update(cancellationToken, model);
        }
        /// <summary>
        /// Delete a user
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
