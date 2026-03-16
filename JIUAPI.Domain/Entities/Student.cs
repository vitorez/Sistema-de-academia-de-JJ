namespace JIUAPI.Domain.Entities;

public class Student
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CurrentBeltId { get; set; } // faixa atual
    public int CurrentDegree { get; set; } = 0; // grau atual 
    public int ClassesCompleted { get; set; } = 0; // aulas que foram completas
    public DateTime EnrolledDate { get; set; } = DateTime.UtcNow; // data de matricula
    public bool IsActive { get; set; } = true; // se está ativo ou n

    public Belt? CurrentBelt { get; set; }
    public ApplicationUser? User { get; set; }
    public ICollection<StudentBeltHistory> BeltHistories { get; set; } = new List<StudentBeltHistory>();
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

}