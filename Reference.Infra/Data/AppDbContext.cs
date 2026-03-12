using Microsoft.EntityFrameworkCore;
using Reference.Domain.Entities;

namespace Reference.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<ApplicationUser> Users { get; set; }
}