using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APP_CEMIG.Models
{
    public class ItemPerfilRepositorio : IItemPerfilRepositorio
    {
        private ItemPerfilContext _context;

        public ItemPerfilRepositorio(ItemPerfilContext context)
        {
            _context = context;
            //Add(new Item { id = 1, descricao = "TV", voltagem = 10, potenciaUso = 10, potenciaSB = 10, foto = new System.Reflection.Metadata.Blob() });
        }

        public void Add(ItemPerfil perfil)
        {
            _context.ItemPerfil.Add(perfil);
            _context.SaveChanges();
        }

        public void Add(Item perfil)
        {
            _context.Item.Add(perfil);
            _context.SaveChanges();
        }

        public ItemPerfil Find(int NumPerfil, long IdItem)
        {
            return _context.ItemPerfil.FirstOrDefault(t => t.NumPerfil == NumPerfil && t.IdItem == IdItem);
        }

        public IEnumerable<ItemPerfilApp> Find(int NumPerfil)
        {
            var teste = _context.ItemPerfil.Where(t => t.NumPerfil == NumPerfil).ToList();
            var items = new List<ItemPerfilApp>();
            foreach (var item in teste)
            {
                item.Item = _context.Item.FirstOrDefault(t => t.id == item.IdItem);

                items.Add(new ItemPerfilApp() { idItem = item.IdItem.ToString(), descricao = item.Item.descricao, DiasUso = item.DiasUso.ToString(), HorasUso = item.HorasUso.ToString(), MinutosUso = item.MinutosUso.ToString(), potencia = item.Item.potenciaUso.ToString(), potenciaSB = item.Item.potenciaSB.ToString(), quantidade = "1", email="" });
            }


            return items;
        }

        public Perfil Find(string email)
        {
            var usu = _context.Usuario.FirstOrDefault(t => t.email == email);
            return _context.Perfil.FirstOrDefault(t => t.CPF == usu.cpf);
            
        }

        public IEnumerable<ItemPerfil> FindItemPerfil(int numPerfil)
        {
            var teste = _context.ItemPerfil.Where(t => t.NumPerfil == numPerfil).ToList();
            foreach (var item in teste)
            {
                item.Item = _context.Item.FirstOrDefault(t => t.id == item.IdItem);
            }
            return teste;
        }

        public IEnumerable<ItemPerfil> GetAll()
        {
            return _context.ItemPerfil.ToList();
        }

        public void Remove(int NumPerfil, long IdItem)
        {
            var entity = _context.ItemPerfil.First(t => t.NumPerfil == NumPerfil && t.IdItem == IdItem);
            _context.ItemPerfil.Remove(entity);
            _context.SaveChanges();
        }

        public Item Ultimo()
        {
            return _context.Item.OrderBy(t => t.id).Last();
        }

        public void Update(ItemPerfil itemPerfil)
        {
            _context.ItemPerfil.Update(itemPerfil);
            _context.SaveChanges();
        }
    }
}
