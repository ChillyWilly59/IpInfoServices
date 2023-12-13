using Microsoft.EntityFrameworkCore;

namespace IpInfoServices.Data
{
    public class ApiDbContext : DbContext
    {

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
        public DbSet<Request> Requests { get; set; }

    }
}
