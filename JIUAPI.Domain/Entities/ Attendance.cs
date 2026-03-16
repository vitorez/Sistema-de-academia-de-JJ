namespace JIUAPI.Domain.Entities;

public class Attendance
{
    public int Id { get; set; }
    public int StudentId { get; set; } // FK para Student
    public int ClassId { get; set; } // FK para Class
    public bool IsPresent { get; set; } = true; //
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    public Student? Student { get; set; }
    public Class? Class { get; set; }
}