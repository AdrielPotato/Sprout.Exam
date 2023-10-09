using AutoMapper;
using Contacts.Application.Mappings;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Sprout.Exam.Business.Commands.UpdateEmployee;
using Sprout.Exam.Business.Repositories;
using Sprout.Exam.Common.Models;
using Sprout.Exam.UnitTest.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sprout.Exam.UnitTest.Commands
{
    public class UpdateEmployeeHandlerTests
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<UpdateEmployeeHandler>> _loggerMock;
        private readonly UpdateEmployeeHandler _handler;

        public UpdateEmployeeHandlerTests()
        {
            //setup
            _employeeRepository = new EmployeeRepositoryFake();
            _loggerMock = new Mock<ILogger<UpdateEmployeeHandler>>();

            var mapperProfile = new MappingProfile();

            mapperProfile.CreateMap<Employee, UpdateEmployeeResponse>()
               .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.EmployeeTypeId))
               .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate.ToString("yyyy-MM-dd")));
            
            mapperProfile.CreateMap<UpdateEmployeeCommand, Employee>()
               .ForMember(dest => dest.EmployeeTypeId, opt => opt.MapFrom(src => src.TypeId))
               .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate.ToString("yyyy-MM-dd")));

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(mapperProfile);
            });
            _mapper = configurationProvider.CreateMapper();

            _handler = new UpdateEmployeeHandler(_employeeRepository, _mapper, _loggerMock.Object);
        }

        [Fact]
        public async Task ShouldPassAsync()
        {
            //Arrange
            var fakeQuery = new UpdateEmployeeCommand()
            {
                Id = 1,
                Birthdate = new DateTime(1999, 01, 01),
                FullName = "Tom Riddle",
                Tin = "12345698",
                TypeId = 2
            };

            //Act
            var result = await _handler.Handle(fakeQuery, new System.Threading.CancellationToken());

            //Assert
            result.Success.Should().BeTrue();
            result.Message.Should().Be("OK");
            result.Payload.Should().NotBeNull();
        }
    }
}
