using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStoreApp.MVC.Domain.Entities;
using System.Data.Entity;

namespace SportsStoreApp.MVC.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        public DbSet<Product> Products { set; get; }
    }
}
