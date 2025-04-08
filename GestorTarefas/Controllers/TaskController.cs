using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestorTarefas.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;


        public TaskController(ITaskService taskService)
        {
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
        }


        [HttpPost]
        public async Task<ActionResult<TaskEntity>> Add(TaskEntity task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            var result = await _taskService.Add(task);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskEntity>>> GetAll()
        {
            var tasks = await _taskService.GetAll();
            return Ok(tasks);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TaskEntity>> GetById(int id)
        {
            var task = await _taskService.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskEntity task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }
            try
            {
                await _taskService.Update(task);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao atualizar a tarefa.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskService.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            await _taskService.Delete(task);
            return NoContent();
        }


        [HttpGet("ByObjective/{objectiveId}")]
        public async Task<ActionResult<IEnumerable<TaskEntity>>> GetTasksByObjectiveId(int objectiveId)
        {
            var tasks = await _taskService.taskEntitiesByObjetiveId(objectiveId);
            return Ok(tasks);
        }
    }

}
