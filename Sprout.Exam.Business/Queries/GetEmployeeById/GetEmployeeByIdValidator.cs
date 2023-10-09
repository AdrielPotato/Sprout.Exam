using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Queries.GetEmployeeById
{
    public class GetEmployeeByIdValidator : AbstractValidator<GetEmployeeByIdQuery>
    {
        public GetEmployeeByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required");
        }
    }
}
