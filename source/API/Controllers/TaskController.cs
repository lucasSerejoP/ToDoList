using API.Application.Commands;
using API.Application.Models.Task;
using API.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITaskQueries _taskQueries;
        public TaskController(IMediator mediator, ITaskQueries queries)
        {
            _mediator = mediator;
            _taskQueries = queries;
        }

        /// <summary>
        /// Criar tarefa
        /// </summary>
        /// <param name="command"></param>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(TaskCreateModel))]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if (result != null)
                {
                    return CreatedAtAction(nameof(CreateTask), new { id = result.Id }, result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        /// <summary>
        /// Atualizar tarefa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskCommand command)
        {
            try
            {
                command.Id = id;
                var result = await _mediator.Send(command);

                if (result)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletar tarefa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var command = new DeleteTaskCommand { Id = id };
                var result = await _mediator.Send(command);

                if (result)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        /// <summary>
        /// Listar todas as  tarefas
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync() =>
            Ok(await _taskQueries.GetAllTasksAsync());

    }
}
