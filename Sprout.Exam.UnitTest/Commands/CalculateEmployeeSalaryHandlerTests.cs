using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Sprout.Exam.Business.Commands.CalculateEmployeeSalary;
using Sprout.Exam.Business.Factories;
using Sprout.Exam.Business.Factories.Interfaces;
using Sprout.Exam.Business.Repositories;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.UnitTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sprout.Exam.UnitTest.Commands
{
    public class CalculateEmployeeSalaryHandlerTests
    {
        private readonly Mock<IEmployeeFactory> _employeeFactoryMock;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly Mock<ILogger<CalculateEmployeeSalaryHandler>> _loggerMock;
        private readonly CalculateEmployeeSalaryHandler _handler;

        public CalculateEmployeeSalaryHandlerTests()
        {
            //setup
            _employeeRepository = new EmployeeRepositoryFake();
            _loggerMock = new Mock<ILogger<CalculateEmployeeSalaryHandler>>();
            _employeeFactoryMock = new Mock<IEmployeeFactory>();
            

            _handler = new CalculateEmployeeSalaryHandler(_employeeFactoryMock.Object,_employeeRepository, _loggerMock.Object);
        }

        [Fact]
        public async Task ShouldRegularEmployeePassAsync()
        {
            //Arrange
            var fakeQuery = new CalculateEmployeeSalaryCommand()
            { 
                Id =1,
                AbsentDays = 1
            };

            _employeeFactoryMock
                .Setup(x => x.CreateEmployee(It.IsAny<EmployeeType>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(new RegularEmployeeFactory(fakeQuery.AbsentDays));

            //Act
            var result = await _handler.Handle(fakeQuery, new System.Threading.CancellationToken());

            //Assert
            result.Success.Should().BeTrue();
            result.Message.Should().Be("OK");
            result.Payload.Should().Be(16690.91m);
        }

        [Fact]
        public async Task ShouldContractualEmployeePassAsync()
        {
            //Arrange
            var fakeQuery = new CalculateEmployeeSalaryCommand()
            {
                Id = 1,
                WorkedDays = 15.5m
            };

            _employeeFactoryMock
                .Setup(x => x.CreateEmployee(It.IsAny<EmployeeType>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns(new ContractualEmployeeFactory(fakeQuery.WorkedDays));

            //Act
            var result = await _handler.Handle(fakeQuery, new System.Threading.CancellationToken());

            //Assert
            result.Success.Should().BeTrue();
            result.Message.Should().Be("OK");
            result.Payload.Should().Be(7750.00m);
        }
    }
}
