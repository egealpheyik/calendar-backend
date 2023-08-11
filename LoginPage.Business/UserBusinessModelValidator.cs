using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginPage.Business
{
    public class UserBusinessModelValidator : AbstractValidator<UserBusinessModel>
    {
        public void CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.pass).NotEmpty();

        }
    }
}
