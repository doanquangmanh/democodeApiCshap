using Demo.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.API.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        // DbSet :
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> loais { get; set; }  
    }
}
