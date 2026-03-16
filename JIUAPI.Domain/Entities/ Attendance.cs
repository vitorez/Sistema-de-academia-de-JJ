namespace JIUAPI.Domain.Entities;

public class Attendance
{
    public int Id { get; set; }
    public int StudentId { get; set; } // chave estrangeira para Student
    public int ClassId { get; set; } // chave estrangeira para Class
    public bool IsPresent { get; set; } = true; //
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    public Student? Student { get; set; }
    public Class? Class { get; set; }
}