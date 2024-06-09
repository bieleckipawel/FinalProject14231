using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject14231.Domain.Entities;

namespace FinalProject14231.Application.Common.Dtos;
public class RentalDto
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Price => (EndDate - StartDate).TotalDays * RentedBike.Price;
    public required Bike RentedBike { get; set; }
    public required Customer Renter { get; set; }
}
