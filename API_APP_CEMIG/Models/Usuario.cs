using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_APP_CEMIG.Models
{
    public class Usuario
    {
        [Key]
        public long cpf { get; set; }
        public string Nome { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string data_nasc { get; set; }  
        public int cep { get; set; }   
        public string rua { get; set; }
        public int number { get; set; }
        public string bairro { get; set; }
        public string uf { get; set; }
        public string complemento { get; set; }
        public string localidade { get; set; }

    }
}
