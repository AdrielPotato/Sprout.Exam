using MediatR;
using Sprout.Exam.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand :IRequest<Result<int>>
    {
        public int Id { get; set; }
    }
}
