using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using To_Do.Application.Subtasks.Requests;
using To_Do.Application.Subtasks.Responses;
using ToDoManagement.Application.Subtasks;

namespace To_Do_API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SubtaskController : ControllerBase
    {
        private readonly ILogger<SubtaskController> _logger;
        private readonly ISubtaskService _service;

        public SubtaskController(ISubtaskService personService, ILogger<SubtaskController> logger)
        {
            _service = personService;
            _logger = logger;

            _logger.LogInformation("controller is executed");
        }

        [HttpGet("{id}")]
        public async Task<SubtaskResponseModel> Get(CancellationToken cancellationToken, int id)
        {
            return await _service.GetAsync(cancellationToken, id);
        }

        [HttpGet]
        public async Task<List<SubtaskResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(cancellationToken);
        }

        [HttpPost]
        public async Task Post(CancellationToken cancellationToken, SubtaskRequestPostModel subtask)
        {
            await _service.CreateAsync(cancellationToken, subtask);
        }

        [HttpPut]
        public async Task Put(CancellationToken cancellationToken, SubtaskRequestPutModel subtask)
        {
            await _service.UpdateAsync(cancellationToken, subtask);
        }

        [HttpDelete]
        public async Task Delete(CancellationToken cancellationToken, int id)
        {
            await _service.DeleteAsync(cancellationToken, id);
        }
    }
}
