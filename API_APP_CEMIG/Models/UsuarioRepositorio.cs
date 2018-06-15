using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APP_CEMIG.Models
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly UsuarioContext _context;

        public UsuarioRepositorio(UsuarioContext context)
        {
            _context = context;
            //Add(new Usuario { cpf = 12956408640, Nome = "Pedro", email = "pedroh_itaboray@hotmail.com", senha = "abc12345" });
        }

        public void Add(Usuario item)
        {
            _context.Usuario.Add(item);
            _context.SaveChanges();
            Perfil novo = new Perfil() { CPF = item.cpf };
            _context.Perfil.Add(novo);
            _context.SaveChanges();
        }

        public Usuario Find(long cpf)
        {
            return _context.Usuario.FirstOrDefault(t => t.cpf == cpf);
        }

        public Usuario Find(string email)
        {
            return _context.Usuario.FirstOrDefault(t => t.email == email);
        }
        
        public Perfil FindPerfil(string email)
        {
            Usuario usu = _context.Usuario.FirstOrDefault(t => t.email == email);
            return _context.Perfil.FirstOrDefault(t => t.CPF == usu.cpf);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuario.ToList();
        }

        public void Remove(long cpf)
        {
            var entity = _context.Usuario.First(t => t.cpf == cpf);
            _context.Usuario.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Usuario item)
        {
            _context.Usuario.Update(item);
            _context.SaveChanges();
        }
    }
}
