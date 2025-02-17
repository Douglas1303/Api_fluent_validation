﻿using FluentValidation;
using Project_Fluent_Validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Fluent_Validation.Validator
{
    public class EntityToValidateValidator : AbstractValidator<EntityToValidate>
    {
        public EntityToValidateValidator()
        {
            RuleFor(t => t.FullName).NotEmpty().Length(2, 50)
                .WithMessage("Please specify a fullname");

            RuleFor(t => t.Age).NotEmpty().InclusiveBetween(18, 50)
                .WithMessage("the min age is 18." );

            RuleFor(t => t.Discount).NotEmpty().GreaterThan(0)
                .LessThanOrEqualTo(100)
                .When(x => x.HasDiscount)
                .WithMessage("The % discount is invalid.");

            RuleFor(t => t.DateOfBirth).Must(ValidDateOfBirth)
                .WithMessage("The date of birth is invalid.");
        }

         private bool ValidDateOfBirth(DateTime dateOfBirth)
        {
            //Owner logic 
            return (dateOfBirth <= DateTime.Today.AddYears(-18)); 
        }
    }
}
