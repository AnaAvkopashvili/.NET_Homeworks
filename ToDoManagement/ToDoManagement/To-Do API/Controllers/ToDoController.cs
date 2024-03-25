using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using To_Do.Application.To_Do.Requests;
using ToDoManagement.Application.To_Do;

namespace To_Do_API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly IToDoService _service;

        public ToDoController(IToDoService service, ILogger<ToDoController> logger)
        {
            _logger = logger;
            _service = service;

            _logger.LogInformation("Controller is executed");
        }
        [HttpGet]
        public async Task<List<ToDoResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(cancellationToken);
        }
        [HttpGet("{id}")]
        public async Task<ToDoResponseModel> Get(CancellationToken cancellationToken, int id)
        {
            return await _service.GetAsync(cancellationToken, id);
        }

        [HttpPost]
        public async Task Post(CancellationToken cancellationToken, ToDoRequestPostModel todo)
        {
            await _service.CreateAsync(cancellationToken, todo);
        }

        [HttpPut]
        public async Task Put(CancellationToken cancellationToken, ToDoRequestPutModel todo)
        {
            await _service.UpdateAsync(cancellationToken, todo);
        }

        [HttpPatch("{id}")]
        public async Task Patch(CancellationToken cancellationToken, ToDoRequestPatchModel todo , int id)
        {
            await _service.PatchAsync(cancellationToken, id, todo);
        }

        [HttpDelete]
        public async Task Delete(CancellationToken cancellationToken, int id)
        {
            await _service.DeleteAsync(cancellationToken, id);
        }
    }
}
