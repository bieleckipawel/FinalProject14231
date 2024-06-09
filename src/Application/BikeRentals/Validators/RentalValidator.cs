using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject14231.Application.Common.Dtos;

namespace FinalProject14231.Application.BikeRentals.Validators;
public class RentalValidator: AbstractValidator<RentalDto>
{
    public RentalValidator()
    {
        RuleFor(r => r.StartDate).NotEmpty()!.WithMessage("Start date is required");
        RuleFor(r => r.EndDate).NotEmpty()!.WithMessage("End date is required");
        RuleFor(r => r.RentedBike).NotNull()!.WithMessage("Rented bike is required");
        RuleFor(r => r.Renter).NotNull()!.WithMessage("Renter is required");
    }
}
