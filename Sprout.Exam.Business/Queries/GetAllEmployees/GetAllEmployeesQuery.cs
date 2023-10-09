using MediatR;
using Sprout.Exam.Business.Queries.GetAllEmployees;
using Sprout.Exam.Common.Models;
using System.Collections.Generic;

namespace Sprout.Exam.Business.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery : IRequest<Result<List<GetAllEmployeesResponse>>>
    {

    }
}
