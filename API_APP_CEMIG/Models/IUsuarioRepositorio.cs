using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APP_CEMIG.Models
{
    public interface IUsuarioRepositorio
    {
        void Add(Usuario item);
        IEnumerable<Usuario> GetAll();
        Usuario Find(long cpf);
        Perfil FindPerfil(string email);
        Usuario Find(string email);
        void Remove(long cpf);
        void Update(Usuario item);
    }
}
