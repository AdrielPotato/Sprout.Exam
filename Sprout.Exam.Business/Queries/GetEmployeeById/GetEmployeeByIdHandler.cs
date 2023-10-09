using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Sprout.Exam.Business.Repositories;
using Sprout.Exam.Common.Models;
using Sprout.Exam.Common.Models.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Queries.GetEmployeeById
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Result<GetEmployeeByIdResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetEmployeeByIdHandler> _logger;

        public GetEmployeeByIdHandler(IEmployeeRepository employeeRepository, IMapper mapper, ILogger<GetEmployeeByIdHandler> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<Result<GetEmployeeByIdResponse>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeAsync(request.Id);
                if (employee == null)
                {
                    throw new NotFoundException("Employee not found");
                }

                var result = _mapper.Map<GetEmployeeByIdResponse>(employee);

                return new Result<GetEmployeeByIdResponse>(result);

            }
            catch (Exception e)
            {
                _logger.LogError("Exception: {error}, EmployeeID {ID} ", e.Message, request.Id);
                throw;
            }
        }
    }
}
