using FluentValidation;
using Sprout.Exam.Common.Enums;

namespace Sprout.Exam.Business.Commands.CreateEmployee
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator()
        {
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
