﻿using FluentAssertions;
using Sprout.Exam.Business.Commands.UpdateEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sprout.Exam.UnitTest.Commands.Validators
{
    public class UpdateEmployeeValidatorTests
    {
        [Fact]
        public void ShouldRequireId()
        {
            // Arrange
            var fakeCmd = new UpdateEmployeeCommand()
            {
                Birthdate = new DateTime(1999, 01, 01),
                FullName = "Tom Riddle",
                Tin = "12345698",
                TypeId = 2
            };

            var fakeValidator = new UpdateEmployeeValidator();

            // Act
            var result = fakeValidator.Validate(fakeCmd);

            // Assert
            result.IsValid.Should().Be(false);
            result.Errors.Count.Should().Be(1);
            result.Errors[0].ErrorMessage.Should().Be("Id is required");
        }

        [Fact]
        public void ShouldRequireBirthdate()
        {
            // Arrange
            var fakeCmd = new UpdateEmployeeCommand()
            {
                Id = 1,
                FullName = "Tom Riddle",
                Tin = "12345698",
                TypeId = 2
            };

            var fakeValidator = new UpdateEmployeeValidator();

            // Act
            var result = fakeValidator.Validate(fakeCmd);

            // Assert
            result.IsValid.Should().Be(false);
            result.Errors.Count.Should().Be(1);
            result.Errors[0].ErrorMessage.Should().Be("Birthdate is required");
        }

        [Fact]
        public void ShouldRequireFullName()
        {
            // Arrange
            var fakeCmd = new UpdateEmployeeCommand()
            {
                Id = 1,
                Birthdate = new DateTime(1999, 01, 01),
                Tin = "12345698",
                TypeId = 2
            };

            var fakeValidator = new UpdateEmployeeValidator();

            // Act
            var result = fakeValidator.Validate(fakeCmd);

            // Assert
            result.IsValid.Should().Be(false);
            result.Errors.Count.Should().Be(1);
            result.Errors[0].ErrorMessage.Should().Be("FullName is required");
        }

        [Fact]
        public void ShouldRequireTin()
        {
            // Arrange
            var fakeCmd = new UpdateEmployeeCommand()
            {
                Id = 1,
                Birthdate = new DateTime(1999, 01, 01),
                FullName = "Tom Riddle",
                TypeId = 2
            };

            var fakeValidator = new UpdateEmployeeValidator();

            // Act
            var result = fakeValidator.Validate(fakeCmd);

            // Assert
            result.IsValid.Should().Be(false);
            result.Errors.Count.Should().Be(1);
            result.Errors[0].ErrorMessage.Should().Be("Tin is required");
        }

        [Fact]
        public void ShouldRequireType()
        {
            // Arrange
            var fakeCmd = new UpdateEmployeeCommand()
            {
                Id = 1,
                Birthdate = new DateTime(1999, 01, 01),
                FullName = "Tom Riddle",
                Tin = "12345698",
            };

            var fakeValidator = new UpdateEmployeeValidator();

            // Act
            var result = fakeValidator.Validate(fakeCmd);

            // Assert
            result.IsValid.Should().Be(false);
            result.Errors.Count.Should().Be(2);
            result.Errors[0].ErrorMessage.Should().Be("TypeId is required");
        }

        [Fact]
        public void ShouldRequireValidType()
        {
            // Arrange
            var fakeCmd = new UpdateEmployeeCommand()
            {
                Id = 1,
                Birthdate = new DateTime(1999, 01, 01),
                FullName = "Tom Riddle",
                Tin = "12345698",
                TypeId = 3
            };

            var fakeValidator = new UpdateEmployeeValidator();

            // Act
            var result = fakeValidator.Validate(fakeCmd);

            // Assert
            result.IsValid.Should().Be(false);
            result.Errors.Count.Should().Be(1);
            result.Errors[0].ErrorMessage.Should().Be("Invalid Type");
        }
    }
}
