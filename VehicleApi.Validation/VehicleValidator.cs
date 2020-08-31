using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApi.Models;
using FluentValidation.Results;

namespace VehicleApi.Validation
{
    public class VehicleValidator : AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(m => m.Year).NotNull().WithMessage("Please specify vehicle Year");

            RuleFor(m => m.Make).NotNull().WithMessage("Please specify vehicle Make");

            RuleFor(m => m.Model).NotNull().WithMessage("Please specify vehicle Model");
        }

        protected override bool PreValidate(ValidationContext<Vehicle> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please submit a non-null model."));

                return false;
            }
            return true;
        }
    }
}
