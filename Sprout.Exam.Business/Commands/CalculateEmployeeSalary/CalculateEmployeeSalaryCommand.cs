using MediatR;
using Sprout.Exam.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Commands.CalculateEmployeeSalary
{
    public class CalculateEmployeeSalaryCommand: IRequest<Result<decimal>>
    {
        public int Id { get; set; }
        public decimal AbsentDays { get; set; }
        public decimal WorkedDays { get; set; }
    }
}
