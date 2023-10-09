using MediatR;
using Sprout.Exam.Common.Models;
using System;

namespace Sprout.Exam.Business.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<Result<CreateEmployeeResponse>>
    {
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Tin { get; set; }
        public int TypeId { get; set; }
    }
}
