namespace FinalProject14231.Domain.Entities;
public class Bike
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public bool IsRented { get; set; }

}
