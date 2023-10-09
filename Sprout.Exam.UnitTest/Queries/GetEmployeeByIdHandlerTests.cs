using AutoMapper;
using Contacts.Application.Mappings;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Sprout.Exam.Business.Queries.GetEmployeeById;
using Sprout.Exam.Business.Repositories;
using Sprout.Exam.Common.Models;
using Sprout.Exam.Common.Models.Exceptions;
using Sprout.Exam.UnitTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sprout.Exam.UnitTest.Queries
{
    public class GetEmployeeByIdHandlerTests
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<GetEmployeeByIdHandler>> _loggerMock;
        private readonly GetEmployeeByIdHandler _handler;

        public GetEmployeeByIdHandlerTests()
        {
            //setup
            _employeeRepository = new EmployeeRepositoryFake();
            _loggerMock = new Mock<ILogger<GetEmployeeByIdHandler>>();

            var mapperProfile = new MappingProfile();

            mapperProfile.CreateMap<Employee, GetEmployeeByIdResponse>()
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.EmployeeTypeId))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate.ToString("yyyy-MM-dd")));

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(mapperProfile);
            });
            _mapper = configurationProvider.CreateMapper();

            _handler = new GetEmployeeByIdHandler(_employeeRepository, _mapper, _loggerMock.Object);
        }

        [Fact]
        public async Task ShouldPassAsync()
        {
            //Arrange
            var fakeQuery = new GetEmployeeByIdQuery()
            {
                Id = 1
            };

            //Act
            var result = await _handler.Handle(fakeQuery, new System.Threading.CancellationToken());

            //Assert
            result.Success.Should().BeTrue();
            result.Message.Should().Be("OK");
            result.Payload.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldThrowEmployeeNotFoundAsync()
        {
            //Arrange
            var fakeQuery = new GetEmployeeByIdQuery()
            {
                Id = 9
            };

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(fakeQuery, new System.Threading.CancellationToken()));
        }
    }
}
