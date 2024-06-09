using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject14231.Domain.Entities;
public class Rental
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Price { get; set; }
    public required Bike RentedBike { get; set; }
    public required Customer Renter { get; set; }

}
