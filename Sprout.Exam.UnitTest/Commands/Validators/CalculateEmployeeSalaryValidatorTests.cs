using FluentAssertions;
using Sprout.Exam.Business.Commands.CalculateEmployeeSalary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sprout.Exam.UnitTest.Commands.Validators
{
    public class CalculateEmployeeSalaryValidatorTests
    {
        [Fact]
        public void ShouldRequireId()
        {
            // Arrange
            var fakeCmd = new CalculateEmployeeSalaryCommand()
            {
                
            };

            var fakeValidator = new CalculateEmployeeSalaryValidator();

            // Act
            var result = fakeValidator.Validate(fakeCmd);

            // Assert
            result.IsValid.Should().Be(false);
            result.Errors.Count.Should().Be(1);
            result.Errors[0].ErrorMessage.Should().Be("Id is required");
        }
    }
}
