using FinalProject14231.Domain.Constants;

namespace FinalProject14231.Domain.Entities;
public class Customer
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public bool HasBikeRented { get; set; }
}
