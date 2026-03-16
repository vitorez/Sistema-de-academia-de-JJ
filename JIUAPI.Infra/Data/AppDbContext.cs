using Microsoft.EntityFrameworkCore;
using JIUAPI.Domain.Entities;

namespace JIUAPI.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Belt> Belts { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<StudentBeltHistory> StudentBeltHistories { get; set; }
}