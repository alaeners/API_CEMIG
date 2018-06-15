using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_APP_CEMIG.Models;

namespace API_APP_CEMIG.Controllers
{
    [Route("api/[controller]")]
    public class ItemPerfilController : Controller
    {
        private readonly IItemPerfilRepositorio _PerfilRepositorio;

        public ItemPerfilController(IItemPerfilRepositorio itemPerfilRepositorio)
        {
            _PerfilRepositorio = itemPerfilRepositorio;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<ItemPerfil> Get()
        {
            return _PerfilRepositorio.GetAll();
        }
        
        [HttpGet("{NumPerfil}/{IdItem}")]
        public IActionResult GetByNumPerfil(int NumPerfil, long IdItem)
        {
            var Perfil = _PerfilRepositorio.Find(NumPerfil, IdItem);
            if (Perfil == null)
            {
                return NotFound();
            }
            return new ObjectResult(Perfil);
        }

        [HttpGet("email/{email}")]
        public IActionResult GetItemPerfilByEmail(string email)
        {
            var Perfil = _PerfilRepositorio.Find(email);
            if (Perfil == null)
            {
                return NotFound();
            }
            return new ObjectResult(Perfil);
        }

        [HttpGet("item/{email}")]
        public IActionResult GetItensByEmail(string email)
        {
            var Perfil = _PerfilRepositorio.Find(email);
            if (Perfil == null)
            {
                return NotFound();
            }

            var item = _PerfilRepositorio.Find(Perfil.NumPerfil);
            return new ObjectResult(item.ToArray());
        }

        [HttpGet("{email}")]
        public IActionResult CalcGasto(string email)
        {

            var Perfil = _PerfilRepositorio.Find(email);
            var ItemPerfil = _PerfilRepositorio.FindItemPerfil(Perfil.NumPerfil);

            if (Perfil == null)
            {
                return NotFound();
            }

            double[] totais = new double[ItemPerfil.Count()];
            int cont = 0;
            foreach (var item in ItemPerfil)
            {
                totais[cont] = (item.Item.potenciaUso * item.DiasUso * (item.HorasUso + (item.MinutosUso / 60))) / 1000; 
                cont++;
            }

            double total = 0;

            foreach (double item in totais)
            {
                total += item;
            }

            total = total * 0.75566591;

            Dictionary<string, double> retorno = new Dictionary<string, double>();

            retorno.Add("Valor", total);

            return new ObjectResult(retorno);
        }

        [HttpPost()]
        public IActionResult Create([FromForm] ItemPerfilApp Perfil)
        {
            if (Perfil == null)
            {
                return BadRequest();
            }

            Perfil perfil = _PerfilRepositorio.Find(Perfil.email);

            for (int i = 0; i < int.Parse(Perfil.quantidade); i++)
            {
                Item novo = new Item() { descricao = Perfil.descricao, potenciaUso = int.Parse(Perfil.potencia) };
                _PerfilRepositorio.Add(novo);
                novo = _PerfilRepositorio.Ultimo();
                ItemPerfil novoo = new ItemPerfil() { DiasUso = int.Parse(Perfil.DiasUso), HorasUso =  int.Parse(Perfil.HorasUso), MinutosUso = int.Parse(Perfil.MinutosUso), IdItem = novo.id, NumPerfil = perfil.NumPerfil };
                _PerfilRepositorio.Add(novoo);
            }
            
            return new ObjectResult(Perfil);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{NumPerfil}/{IdItem}")]
        public IActionResult Delete(int NumPerfil, long IdItem)
        {
            var todo = _PerfilRepositorio.Find(NumPerfil, IdItem);
            if (todo == null)
            {
                return NotFound();
            }

            _PerfilRepositorio.Remove(NumPerfil, IdItem);
            return new NoContentResult();
        }
    }
}