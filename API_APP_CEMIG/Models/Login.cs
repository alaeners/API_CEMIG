using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_APP_CEMIG.Models
{
    public class Login
    {
        public string email { get; set; }
        public string senha { get; set; }
    }
}
