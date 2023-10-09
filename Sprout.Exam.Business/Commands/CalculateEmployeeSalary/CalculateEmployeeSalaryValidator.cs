using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Commands.CalculateEmployeeSalary
{
    public class CalculateEmployeeSalaryValidator : AbstractValidator<CalculateEmployeeSalaryCommand>
    {
        public CalculateEmployeeSalaryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required");
            RuleFor(x => x.AbsentDays)
                .GreaterThanOrEqualTo(0)
                .WithMessage("AbsentDays is required");
            RuleFor(x => x.WorkedDays)
                .GreaterThanOrEqualTo(0)
                .WithMessage("WorkedDays is required");
        }
    }
}
