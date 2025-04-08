using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestorTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }


        [HttpPost]
        public async Task<ActionResult<User>> Add(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var result = await _userService.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            try
            {
                await _userService.Update(user);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao atualizar o usuário.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userService.Delete(user);
            return NoContent();
        }


        [HttpPost("Login")]
        public async Task<ActionResult<bool>> Login(string username, string password)
        {
            var result = await _userService.Login(username, password);
            return Ok(result);
        }
    }
}
