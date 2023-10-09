using MediatR;
using Microsoft.Extensions.Logging;
using Sprout.Exam.Business.Repositories;
using Sprout.Exam.Common.Models;
using Sprout.Exam.Common.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Commands.DeleteEmployee
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, Result<int>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<DeleteEmployeeHandler> _logger;
        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository, ILogger<DeleteEmployeeHandler> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }


        public async Task<Result<int>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeAsync(request.Id);
                if (employee == null)
                {
                    throw new NotFoundException("Employee not found");
                }

                var isSuccess = await _employeeRepository.DeleteAsync(employee);
                if (!isSuccess)
                {
                    return Result<int>.Error(500, "Deletion of employee was unsuccessful");
                }

                return new Result<int>(employee.Id);
            }
            catch (Exception e)
            {
                _logger.LogError("Exception: {error}, EmployeeID {ID} ", e.Message, request.Id);
                throw;
            }
        }
    }
}
