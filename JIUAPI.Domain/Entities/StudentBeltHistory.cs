namespace JIUAPI.Domain.Entities;

public class StudentBeltHistory
{
    public int Id { get; set; }
    public int StudentId { get; set; } // FK para Student
    public int BeltId { get; set; } // FK para Belt
    public int DegreeAchieved { get; set; } // Qual grau atingiu (0-3)
    public DateTime PromotedAt { get; set; } = DateTime.UtcNow; // Quando foi promovido
    public string? Notes { get; set; } // Observações (ex: "Treino extra concluído")

    // Relacionamentos
    public Student? Student { get; set; }
    public Belt? Belt { get; set; }
}