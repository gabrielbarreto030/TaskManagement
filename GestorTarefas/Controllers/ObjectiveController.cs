using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestorTarefas.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ObjectiveController : ControllerBase
    {
        private readonly IObjectiveService _objectiveService;


        public ObjectiveController(IObjectiveService objectiveService)
        {
            _objectiveService = objectiveService ?? throw new ArgumentNullException(nameof(objectiveService));
        }


        [HttpPost]
        public async Task<ActionResult<ObjectEntity>> Add(ObjectEntity objective)
        {
            if (objective == null)
            {
                return BadRequest();
            }
            var result = await _objectiveService.Add(objective);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjectEntity>>> GetAll()
        {
            var objectives = await _objectiveService.GetAll();
            return Ok(objectives);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ObjectEntity>> GetById(int id)
        {
            var objective = await _objectiveService.GetById(id);
            if (objective == null)
            {
                return NotFound();
            }
            return Ok(objective);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ObjectEntity objective)
        {
            if (id != objective.Id)
            {
                return BadRequest();
            }
            try
            {
                await _objectiveService.Update(objective);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao atualizar o objetivo.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var objective = await _objectiveService.GetById(id);
            if (objective == null)
            {
                return NotFound();
            }
            await _objectiveService.Delete(objective);
            return NoContent();
        }


        [HttpGet("ByUser/{userId}")]
        public async Task<ActionResult<IEnumerable<ObjectEntity>>> GetObjectivesByUserId(int? userId)
        {
            var objectives = await _objectiveService.GetAllObjectEntities(userId);
            return Ok(objectives);
        }
    }
}
