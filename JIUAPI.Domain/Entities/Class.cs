namespace JIUAPI.Domain.Entities;

public class Class
{
    public int Id { get; set; }
    public DateTime ClassDate { get; set; }
    public string? Description { get; set; } // Ex: "Treino de polimento", "Aula de defesa"
    public int InstructorUserId { get; set; } // FK para professor (ApplicationUser)
    public bool IsCanceled { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Relacionamentos
    public ApplicationUser? Instructor { get; set; }
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}