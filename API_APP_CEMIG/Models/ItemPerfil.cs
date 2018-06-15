using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_APP_CEMIG.Models
{
    public class ItemPerfil
    {
        [ForeignKey("Perfil")]
        public int NumPerfil { get; set; }        
        public virtual Perfil Perfil { get; set; }
        
        [ForeignKey("Item")]
        public long IdItem { get; set; }
        public virtual Item Item { get; set; }

        public int DiasUso { get; set; }
        public int HorasUso { get; set; }
        public int MinutosUso { get; set; }      

    }
}
