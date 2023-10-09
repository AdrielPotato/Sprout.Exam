using AutoMapper;
using Contacts.Application.Mappings;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Sprout.Exam.Business.Queries.GetAllEmployees;
using Sprout.Exam.Business.Repositories;
using Sprout.Exam.Common.Models;
using Sprout.Exam.UnitTest.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace Sprout.Exam.UnitTest.Queries
{
    public class GetAllEmployeesHandlerTests
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<GetAllEmployeesHandler>> _loggerMock;
        private readonly GetAllEmployeesHandler _handler;

        public GetAllEmployeesHandlerTests()
        {
            //setup
            _employeeRepository = new EmployeeRepositoryFake();
            _loggerMock = new Mock<ILogger<GetAllEmployeesHandler>>();

            var mapperProfile = new MappingProfile();

            mapperProfile.CreateMap<Employee, GetAllEmployeesResponse>()
                .ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.EmployeeTypeId))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate.ToString("yyyy-MM-dd")));

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(mapperProfile);
            });
            _mapper = configurationProvider.CreateMapper();

            _handler = new GetAllEmployeesHandler(_employeeRepository, _mapper, _loggerMock.Object);
        }


        [Fact]
        public async Task ShouldPassAsync()
        {
            //Arrange
            var fakeQuery = new GetAllEmployeesQuery();

            //Act
            var result = await _handler.Handle(fakeQuery, new System.Threading.CancellationToken());

            //Assert
            result.Success.Should().BeTrue();
            result.Message.Should().Be("OK");
            result.Payload.Should().NotBeNull();
            result.Payload.Count.Should().Be(4);
        }
    }
}
