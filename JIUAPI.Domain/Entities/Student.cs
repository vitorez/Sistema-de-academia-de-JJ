namespace JIUAPI.Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CurrentBeltId { get; set; } // Faixa atual
    public int CurrentDegree { get; set; } = 0; // Grau atual (0-3 geralmente)
    public int ClassesCompleted { get; set; } = 0; // Total de aulas completadas
    public DateTime EnrolledDate { get; set; } = DateTime.UtcNow; // Data de inscrição
    public bool IsActive { get; set; } = true; // Se está ativo/inativo

    public Belt? CurrentBelt { get; set; }
    public ApplicationUser? User { get; set; }
    public ICollection<StudentBeltHistory> BeltHistories { get; set; } = new List<StudentBeltHistory>();
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

}