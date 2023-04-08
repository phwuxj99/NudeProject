using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace NudeProject.Models
{
    public class NudeDBContext : DbContext
    {
        public NudeDBContext(DbContextOptions<NudeDBContext> dbContextOptions) : base(dbContextOptions)
        { }
        public DbSet<Product> Products { get; set; }
    }
}
