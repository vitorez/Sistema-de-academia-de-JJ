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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração dos relacion
        modelBuilder.Entity<Student>()
            .HasOne(s => s.User)
            .WithMany()
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Student>()
            .HasOne(s => s.CurrentBelt)
            .WithMany()
            .HasForeignKey(s => s.CurrentBeltId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Class>()
            .HasOne(c => c.Instructor)
            .WithMany()
            .HasForeignKey(c => c.InstructorUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Student)
            .WithMany(s => s.Attendances)
            .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Class)
            .WithMany(c => c.Attendances)
            .HasForeignKey(a => a.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StudentBeltHistory>()
            .HasOne(sbh => sbh.Student)
            .WithMany(s => s.BeltHistories)
            .HasForeignKey(sbh => sbh.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StudentBeltHistory>()
            .HasOne(sbh => sbh.Belt)
            .WithMany(b => b.StudentBeltHistories)
            .HasForeignKey(sbh => sbh.BeltId)
            .OnDelete(DeleteBehavior.Restrict);

        // faixas
        modelBuilder.Entity<Belt>().HasData(
            new Belt { Id = 1, Name = "Branca", Order = 0, ClassesNeededForPromotion = 20, MaxDegrees = 4 },
            new Belt { Id = 2, Name = "Azul", Order = 1, ClassesNeededForPromotion = 20, MaxDegrees = 4 },
            new Belt { Id = 3, Name = "Roxa", Order = 2, ClassesNeededForPromotion = 20, MaxDegrees = 4 },
            new Belt { Id = 4, Name = "Marrom", Order = 3, ClassesNeededForPromotion = 20, MaxDegrees = 4 },
            new Belt { Id = 5, Name = "Preta", Order = 4, ClassesNeededForPromotion = 0, MaxDegrees = 10 }
        );
    }

}