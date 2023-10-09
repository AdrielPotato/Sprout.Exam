using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Sprout.Exam.Business.Commands.DeleteEmployee;
using Sprout.Exam.Business.Repositories;
using Sprout.Exam.UnitTest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sprout.Exam.UnitTest.Commands
{
    public class DeleteEmployeeHandlerTests
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly Mock<ILogger<DeleteEmployeeHandler>> _loggerMock;
        private readonly DeleteEmployeeHandler _handler;

        public DeleteEmployeeHandlerTests()
        {
            //setup
            _employeeRepository = new EmployeeRepositoryFake();
            _loggerMock = new Mock<ILogger<DeleteEmployeeHandler>>();

            _handler = new DeleteEmployeeHandler(_employeeRepository, _loggerMock.Object);
        }

        [Fact]
        public async Task ShouldPassAsync()
        {
            //Arrange
            var fakeQuery = new DeleteEmployeeCommand()
            {
                Id = 1
            };

            //Act
            var result = await _handler.Handle(fakeQuery, new System.Threading.CancellationToken());

            //Assert
            result.Success.Should().BeTrue();
            result.Message.Should().Be("OK");
        }
    }
}
