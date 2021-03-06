﻿using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRule.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {


        public CarValidator()
        {
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
        }
        
    }
}