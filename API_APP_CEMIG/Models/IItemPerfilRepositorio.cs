using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APP_CEMIG.Models
{
    public interface IItemPerfilRepositorio
    {
        void Add(ItemPerfil perfil);
        void Add(Item perfil);
        IEnumerable<ItemPerfil> GetAll();
        ItemPerfil Find(int NumPerfil, long IDItem);
        Perfil Find(string email);
        IEnumerable<ItemPerfilApp> Find(int NumPerfil);
        void Remove(int NumPerfil, long IDItem);
        void Update(ItemPerfil itemPerfil);
        Item Ultimo();
        IEnumerable<ItemPerfil> FindItemPerfil(int numPerfil);
    }
}
