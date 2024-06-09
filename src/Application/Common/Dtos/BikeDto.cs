using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject14231.Application.Common.Dtos;
public class BikeDto
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public string? Description { get; set; }
    [Required]
    public double Price { get; set; }
    public bool IsRented { get; set; }
}
