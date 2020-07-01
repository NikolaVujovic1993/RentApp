using Application.DataTransfer.RequestDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentApp.Helpers.Validators
{
    public class VehicleValidator : AbstractValidator<VehicleRequestDTO>
    {
        public VehicleValidator()
        {
            RuleFor(x => x.Model)
                .NotNull()
                .MaximumLength(20);
        }
    }
}
