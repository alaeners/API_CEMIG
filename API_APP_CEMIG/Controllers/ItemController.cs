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
    public class ItemController : Controller
    {

        private readonly IItemRepositorio _ItemRepositorio;

        public ItemController(IItemRepositorio usuarioRepositorio)
        {
            _ItemRepositorio = usuarioRepositorio;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _ItemRepositorio.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetItem")]
        public IActionResult GetByCPF(long id)
        {
            var item = _ItemRepositorio.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromForm] Item item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _ItemRepositorio.Add(item);

            return new ObjectResult(item);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromForm] Item item)
        {
            if (item == null || item.id != id)
            {
                return BadRequest();
            }

            var itemA = _ItemRepositorio.Find(id);
            if (itemA == null)
            {
                return NotFound();
            }

            Usuario atualizar = new Usuario();
            
            itemA.descricao = item.descricao;
            itemA.voltagem = item.voltagem;
            itemA.potenciaUso = item.potenciaUso;
            itemA.potenciaSB = item.potenciaSB;
            itemA.foto = item.foto;


            _ItemRepositorio.Update(itemA);
            return new NoContentResult();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _ItemRepositorio.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _ItemRepositorio.Remove(id);
            return new NoContentResult();
        }
    }
}
