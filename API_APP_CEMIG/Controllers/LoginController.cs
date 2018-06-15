using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_APP_CEMIG.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_APP_CEMIG.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        private readonly IUsuarioRepositorio _UsuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _UsuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost]
        public IActionResult Login([FromForm] Login item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Usuario log = _UsuarioRepositorio.Find(item.email);
            if(log.password == item.senha)
            {
              return new OkResult();
            }
           return new UnauthorizedResult();
        }
    }
}
