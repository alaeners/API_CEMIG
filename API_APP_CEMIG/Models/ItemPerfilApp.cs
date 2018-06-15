using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_APP_CEMIG.Models
{
    public class ItemPerfilApp
    {
        public string idItem { get; set; }
        public string descricao { get; set; }
        public string potencia { get; set; }
        public string potenciaSB { get; set; }
        public string quantidade { get; set; }
        public string DiasUso { get; set; }
        public string HorasUso { get; set; }
        public string MinutosUso { get; set; }
        public string email { get; set; }
    }
}
