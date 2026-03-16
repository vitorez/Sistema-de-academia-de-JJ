namespace JIUAPI.Domain.Entities;

public class StudentBeltHistory
{
    public int Id { get; set; }
    public int StudentId { get; set; } // chave estrangeira para Student
    public int BeltId { get; set; } // chave estrangeira para Belt
    public int DegreeAchieved { get; set; } // qual foi o grau atingidio
    public DateTime PromotedAt { get; set; } = DateTime.UtcNow; // data que foi promovido
    public string? Notes { get; set; } // anotacoes sobre o treino

    // relacionamentos
    public Student? Student { get; set; }
    public Belt? Belt { get; set; }
}