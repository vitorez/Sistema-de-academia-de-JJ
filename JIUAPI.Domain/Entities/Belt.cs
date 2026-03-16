namespace JIUAPI.Domain.Entities;

public class Belt
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // "Branca", "Azul", "Roxa", etc
    public int Order { get; set; } // Ordem de progressão (0 = Branca, 1 = Azul, etc)
    public int ClassesNeededForPromotion { get; set; } = 20; // Quantas aulas para promover
    public int MaxDegrees { get; set; } = 4; // Máximo de graus nesta faixa

    // Relacionamento
    public ICollection<StudentBeltHistory> StudentBeltHistories { get; set; } = new List<StudentBeltHistory>();

}