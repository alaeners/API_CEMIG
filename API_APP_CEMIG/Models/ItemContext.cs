using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APP_CEMIG.Models
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) 
        : base(options)
        {}

        public DbSet<Item> Item { get; set; }
    }
}
