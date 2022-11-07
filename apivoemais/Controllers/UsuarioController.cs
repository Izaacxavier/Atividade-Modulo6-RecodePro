using apivoemais.Model;
using apivoemais.Repository;
using Microsoft.AspNetCore.Mvc;

namespace myprojet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository){
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var usuarios = await _repository.GetUsuarios();
            return usuarios.Any() ? Ok(usuarios) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            var usuario = await _repository.GetUsuarioById(id);
            return usuario != null ? Ok(usuario) : NotFound("Usuário não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario){
            _repository.AddUsuario(usuario);
            return await _repository.SaveChangesAsync() ? Ok("Usuário Adicionado") : BadRequest("Algo deu errado.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Usuario usuario){
            var usuarioExiste = await _repository.GetUsuarioById(id);
            if(usuarioExiste == null) return NotFound("Usuário não encontrado.");

            _repository.AtualizarUsuario(usuarioExiste);
            return await _repository.SaveChangesAsync() ? Ok("Usuário Atualizado") : BadRequest("Algo deu errado.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var usuarioExiste = await _repository.GetUsuarioById(id);
            if(usuarioExiste == null) return NotFound("Usuário não encontrado.");

            _repository.DeletarUsuario(usuarioExiste);
            return await _repository.SaveChangesAsync() ? Ok("Usuário Excluído") : BadRequest("Algo deu errado.");

        }
    }
}