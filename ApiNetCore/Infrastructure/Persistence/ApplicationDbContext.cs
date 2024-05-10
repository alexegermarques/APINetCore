using Microsoft.EntityFrameworkCore;

namespace ApiNetCore;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
