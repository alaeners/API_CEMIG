using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APP_CEMIG.Models
{
    public class ItemRepositorio : IItemRepositorio
    {
        private ItemContext _context;

        public ItemRepositorio(ItemContext context)
        {
            _context = context;
            //Add(new Item { id = 1, descricao = "TV", voltagem = 10, potenciaUso = 10, potenciaSB = 10, foto = new System.Reflection.Metadata.Blob() });
        }

        public void Add(Item item)
        {
            _context.Item.Add(item);
            _context.SaveChanges();
        }

        public Item Find(long id)
        {
            return _context.Item.FirstOrDefault(t => t.id == id);
        }

        public IEnumerable<Item> GetAll()
        {
            return _context.Item.ToList();
        }

        public void Remove(long id)
        {
            var entity = _context.Item.First(t => t.id == id);
            _context.Item.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Item item)
        {
            _context.Item.Update(item);
            _context.SaveChanges();
        }
    }
}
