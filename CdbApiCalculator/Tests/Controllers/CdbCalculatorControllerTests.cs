using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using NUnit.Framework;
using Moq;
using CdbApiCalculator.Controllers;
using CdbApiCalculator.Models;

namespace CdbApiCalculator.Tests.Controllers
{
    [TestFixture]
    public class CdbCalculatorControllerTests
    {
        private CdbCalculatorController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new CdbCalculatorController();
        }

        [Test]
        public void Test_Calculate_InvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = _controller.Calculate(new CdbInput());

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestErrorMessageResult>());
        }

        [Test]
        public void Test_Calculate_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            var input = new CdbInput { InitialValue = 1000, Months = 12 };

            // Act
            var result = _controller.Calculate(input);

            // Assert
            var okResult = result as OkNegotiatedContentResult<CdbResult>;
            Assert.NotNull(okResult);
            Assert.AreEqual(1080m, okResult.Content.GrossValue);  
            Assert.AreEqual(864m, okResult.Content.NetValue);  
        }
    }
}