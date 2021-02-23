using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(2);
        }
    }
}
