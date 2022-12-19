using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Authenticate.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=LAPTOP-5ETPORJT; Database=identityAuth; integrated security=true");

        }

        public DbSet<Admin> Admins { get; set; }    

    }

}
