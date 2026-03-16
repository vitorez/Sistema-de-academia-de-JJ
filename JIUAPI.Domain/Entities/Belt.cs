namespace JIUAPI.Domain.Entities;

public class Belt
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }
    public int ClassesNeededForPromotion { get; set; } = 20;
    public int MaxDegrees { get; set; } = 4;

    // com quem ela se relaciona
    public ICollection<StudentBeltHistory> StudentBeltHistories { get; set; } = new List<StudentBeltHistory>();

}