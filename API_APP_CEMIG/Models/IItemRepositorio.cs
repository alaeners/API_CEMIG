using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APP_CEMIG.Models
{
    public interface IItemRepositorio
    {
        void Add(Item item);
        IEnumerable<Item> GetAll();
        Item Find(long cpf);
        void Remove(long cpf);
        void Update(Item item);
    }
}
