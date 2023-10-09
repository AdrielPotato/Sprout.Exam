using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Sprout.Exam.Business.Queries;
using Sprout.Exam.Business.Queries.GetAllEmployees;
using Sprout.Exam.Business.Repositories;
using Sprout.Exam.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Queries.GetAllEmployees
{
    public class GetAllEmployeesHandler : IRequestHandler<GetAllEmployeesQuery, Result<List<GetAllEmployeesResponse>>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllEmployeesHandler> _logger;

        public GetAllEmployeesHandler(IEmployeeRepository employeeRepository, IMapper mapper, ILogger<GetAllEmployeesHandler> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<List<GetAllEmployeesResponse>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var employees = await _employeeRepository.GetEmployeesAsync();
                var result = _mapper.Map<List<GetAllEmployeesResponse>>(employees);

                return new Result<List<GetAllEmployeesResponse>>(result);
            }
            catch (Exception e)
            {
                _logger.LogError("Exception: {error}", e.Message);
                throw;
            }

        }
    }
}
