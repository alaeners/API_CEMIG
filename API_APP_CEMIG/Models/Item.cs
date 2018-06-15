using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace API_APP_CEMIG.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string descricao { get; set; }
        public int voltagem { get; set; }
        public int potenciaUso { get; set; }
        public int potenciaSB { get; set; }   
        public byte[] foto { get; set; }
    }
}
