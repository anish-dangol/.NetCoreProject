using System;
using System.Collections.Generic;
using System.Text;
using VehicleApi.Models;
using FluentValidation.Results;

namespace VehicleApi.Validation
{
    public static class ValidationExtensions
    {
        public static bool IsValid(this Vehicle vehicle, out IEnumerable<string> errors)
        {
            var validator = new VehicleValidator();

            var validationResult = validator.Validate(vehicle);

            errors = AggregateErrors(validationResult);

            return validationResult.IsValid;
        }

        private static List<string> AggregateErrors(ValidationResult validationResult)
        {
            var errors = new List<string>();

            if (!validationResult.IsValid)
                foreach (var error in validationResult.Errors)
                    errors.Add(error.ErrorMessage);

            return errors;
        }
    }
}
