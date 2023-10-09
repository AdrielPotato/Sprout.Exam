using FluentValidation;
using Sprout.Exam.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Commands.UpdateEmployee
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required");
            RuleFor(x => x.Birthdate)
                .NotEmpty()
                .WithMessage("Birthdate is required");
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("FullName is required");
            RuleFor(x => x.Tin)
                .NotEmpty()
                .WithMessage("Tin is required");
            RuleFor(x => x.TypeId)
                .NotEmpty()
                .WithMessage("TypeId is required")
                .Must(x =>
                    x == (int)EmployeeType.Regular ||
                    x == (int)EmployeeType.Contractual)
                .WithMessage("Invalid Type");
        }
    }
}
