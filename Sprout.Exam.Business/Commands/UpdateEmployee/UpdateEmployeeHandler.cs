using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Sprout.Exam.Business.Repositories;
using Sprout.Exam.Common.Models;
using Sprout.Exam.Common.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Commands.UpdateEmployee
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, Result<UpdateEmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateEmployeeHandler> _logger;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper, ILogger<UpdateEmployeeHandler> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<UpdateEmployeeResponse>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //check if employee exists
                var employee = await _employeeRepository.GetEmployeeAsync(request.Id);

                if (employee == null)
                {
                    throw new NotFoundException("Employee not found");
                }

                employee.FullName = request.FullName;
                employee.Birthdate = request.Birthdate;
                employee.Tin = request.Tin;
                employee.EmployeeTypeId = request.TypeId;

                var isSuccess = await _employeeRepository.UpdateAsync(employee);
                if (!isSuccess)
                {
                    return Result<UpdateEmployeeResponse>.Error(500, "", new List<string>() { "Update was unsuccessful" });
                }

                var result = _mapper.Map<UpdateEmployeeResponse>(employee);
                return new Result<UpdateEmployeeResponse>(result);

            }
            catch (Exception e)
            {
                _logger.LogError("Exception: {error}, EmployeeID {ID} ", e.Message, request.Id);
                throw;
            }
        }
    }
}
