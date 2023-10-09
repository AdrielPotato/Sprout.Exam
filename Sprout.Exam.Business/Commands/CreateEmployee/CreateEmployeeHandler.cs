using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Sprout.Exam.Business.Repositories;
using Sprout.Exam.Common.Models;
using Sprout.Exam.Common.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Commands.CreateEmployee
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Result<CreateEmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateEmployeeHandler> _logger;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper, ILogger<CreateEmployeeHandler> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<CreateEmployeeResponse>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newEmployee = _mapper.Map<Employee>(request);

                var isSuccess = await _employeeRepository.CreateAsync(newEmployee);
                if (!isSuccess)
                {
                    return Result<CreateEmployeeResponse>.Error(500, "", new List<string>() { "Creation of employee was unsuccessful" });
                }

                return new Result<CreateEmployeeResponse>(new CreateEmployeeResponse(newEmployee.Id))
                {
                    StatusCode = (int)HttpStatusCode.Created
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Exception: {error}, FullName {fullname}, Birthdate {birthdate}, Tim {tim}, Type {type} ", e.Message, request.FullName, request.Birthdate, request.Tin, request.TypeId);
                throw;
            }
        }
    }
}
