using MediatR;
using Sprout.Exam.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery: IRequest<Result<GetEmployeeByIdResponse>>
    {
        public int Id { get; set; }
    }
}
