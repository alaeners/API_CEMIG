using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_APP_CEMIG.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_APP_CEMIG.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _UsuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _UsuarioRepositorio = usuarioRepositorio;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _UsuarioRepositorio.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{cpf}", Name = "GetUsuario")]
        [Produces("application/json")]
        public IActionResult GetByCPF(long cpf)
        {
            var item = _UsuarioRepositorio.Find(cpf);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("email/{email}", Name = "GetUsuarioByEmail")]
        [Produces("application/json")]
        public IActionResult GetByEmail(string email)
        {
            var item = _UsuarioRepositorio.Find(email);
            if (item == null)
            {
                return NotFound();
            }
             return new ObjectResult(item);
        }

        [HttpGet("perfil/{email}", Name = "GetPerfilByEmail")]
        [Produces("application/json")]
        public IActionResult GetPerfil(string email)
        {
            var item = _UsuarioRepositorio.FindPerfil(email);
            if (item == null)
            {
                return NotFound();
            }
             return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromForm] Usuario item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _UsuarioRepositorio.Add(item);
            return new ObjectResult(item);           
        }

        // PUT api/<controller>/5
        [HttpPut("{cpf}")]
        public IActionResult Update(long cpf, [FromForm] Usuario item)
        {
            if (item == null || item.cpf != cpf)
            {
                return BadRequest();
            }

            var usuario = _UsuarioRepositorio.Find(cpf);
            if (usuario == null)
            {
                return NotFound();
            }

            Usuario atualizar = new Usuario();

            usuario.cpf = item.cpf;
            usuario.Nome = item.Nome;
            usuario.bairro = item.bairro;
            usuario.cep = item.cep;
            usuario.complemento = item.complemento;
            usuario.data_nasc = item.data_nasc;
            usuario.email = item.email;
            usuario.localidade = item.localidade;
            usuario.number = item.number;
            usuario.password = item.password;
            usuario.rua = item.rua;
            usuario.uf = item.uf;

            _UsuarioRepositorio.Update(usuario);
            return new NoContentResult();
        }

         // PUT api/<controller>/5
        [HttpPut("email/{emailatual}")]
        public IActionResult UpdateEmail(string emailatual, [FromForm] Usuario item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var usuario = _UsuarioRepositorio.Find(emailatual);
            if (usuario == null)
            {
                return NotFound();
            }
            else if(usuario.cpf != item.cpf)
            {
                return BadRequest();
            }

            Usuario atualizar = new Usuario();

            usuario.cpf = item.cpf;
            usuario.Nome = item.Nome;
            usuario.bairro = item.bairro;
            usuario.cep = item.cep;
            usuario.complemento = item.complemento;
            usuario.data_nasc = item.data_nasc;
            usuario.email = item.email;
            usuario.localidade = item.localidade;
            usuario.number = item.number;
            usuario.password = item.password;
            usuario.rua = item.rua;
            usuario.uf = item.uf;

            _UsuarioRepositorio.Update(usuario);
            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{cpf}")]
        public IActionResult Delete(long cpf)
        {
            var todo = _UsuarioRepositorio.Find(cpf);
            if (todo == null)
            {
                return NotFound();
            }

            _UsuarioRepositorio.Remove(cpf);
            return new NoContentResult();
        }

        [HttpDelete("email/{email}")]
        public IActionResult DeleteEmail(string email)
        {
            var todo = _UsuarioRepositorio.Find(email);
            if (todo == null)
            {
                return NotFound();
            }

            _UsuarioRepositorio.Remove(todo.cpf);
            return new NoContentResult();
        }
    }
}
