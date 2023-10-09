using MediatR;
using Microsoft.Extensions.Logging;
using Sprout.Exam.Business.Factories.Interfaces;
using Sprout.Exam.Business.Repositories;
using Sprout.Exam.Common.Models;
using Sprout.Exam.Common.Models.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;
using EmployeeType = Sprout.Exam.Common.Enums.EmployeeType;

namespace Sprout.Exam.Business.Commands.CalculateEmployeeSalary
{
    public class CalculateEmployeeSalaryHandler : IRequestHandler<CalculateEmployeeSalaryCommand, Result<decimal>>
    {
        private readonly IEmployeeFactory _employeeFactory;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<CalculateEmployeeSalaryHandler> _logger;
        public CalculateEmployeeSalaryHandler(IEmployeeFactory employeeFactory, IEmployeeRepository employeeRepository, ILogger<CalculateEmployeeSalaryHandler> logger)
        {
            _employeeFactory = employeeFactory;
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task<Result<decimal>> Handle(CalculateEmployeeSalaryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeAsync(request.Id);
                if (employee == null)
                {
                    throw new NotFoundException("Employee not found");
                }

                var type = (EmployeeType)employee.EmployeeTypeId;
                var employeeFactory = _employeeFactory.CreateEmployee(type, request.AbsentDays, request.WorkedDays);
                var salary = employeeFactory.GetSalary();

                return new Result<decimal>(salary);
            }
            catch (Exception e)
            {
                _logger.LogError("Exception: {error}, EmployeeID {ID} ", e.Message, request.Id);
                throw;
            }
        }
    }
}
