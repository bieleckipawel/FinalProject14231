using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject14231.Domain.Enums;

namespace FinalProject14231.Application.Common.Dtos;
public class CustomerDto
{
    public int Id { get; set; }
    [Required]
    public required string FirstName { get; set; }
    [Required]
    public required string LastName { get; set; }
    public string? Email { get; set; }
    [Required]
    public bool HasBikeRented { get; set; }
}
