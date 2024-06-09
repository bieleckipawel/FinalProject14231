using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject14231.Application.Common.Dtos;
using FluentValidation;

namespace FinalProject14231.Application.BikeRentals.Validators;
public class BikeValidator: AbstractValidator<BikeDto>
{
    public BikeValidator()
    {
        RuleFor(b => b.Name).NotEmpty()!.WithMessage("Name is required");
        RuleFor(b => b.Price).GreaterThan(0).WithMessage("Price cannot be zero or less");
    }
}
