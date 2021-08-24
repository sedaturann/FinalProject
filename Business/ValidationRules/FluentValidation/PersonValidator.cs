using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.PersonName).NotEmpty();
            RuleFor(p => p.PersonName).MinimumLength(2);
            RuleFor(p => p.PersonId).NotEmpty();
        }
    }
}
