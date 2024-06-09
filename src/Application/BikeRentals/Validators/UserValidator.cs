using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject14231.Application.Common.Dtos;

namespace FinalProject14231.Application.BikeRentals.Validators;
public class UserValidator: AbstractValidator<CustomerDto>
{
    public UserValidator()
    {
        RuleFor(u => u.FirstName).NotEmpty()!.WithMessage("First name is required");
        RuleFor(u => u.LastName).NotEmpty()!.WithMessage("Last name is required");
    }
}
