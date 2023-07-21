namespace crud.test.Infrastructure.EF.Models;

public class ProductReadModel
{
    public bool IsAvailable { get; set; }
    public string ManufactureEmail { get; set; }
    public string ManufacturePhone { get; set; }
    public DateTime ProduceDate { get; set; }
    public string Name { get; set; }
    public Guid Id { get; set; }
}