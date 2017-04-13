using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entity;

namespace MyContext
{
    public class ContextDB : DbContext
    {
       public DbSet<Movie> Movies { get; set; }
    }
}
