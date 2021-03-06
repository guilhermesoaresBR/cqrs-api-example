﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using CQRSExample.ProductApi.Domain.Commands.Product;
using CQRSExample.ProductApi.Domain.Validations.Product;

namespace CQRSExample.ProductApi.Tests.UnitTest.Domain.Validations
{
    [TestClass]
    public class CreateProductCommandValidationTests
    {
        private CreateProductCommandValidation validator;

        [TestInitialize]
        public void Initialize()
        {
            validator = new CreateProductCommandValidation();
        }

        [TestMethod]
        public void ShouldHaveErrorWhenNameIsNull()
        {
            // Arrange
            var command = new CreateProductCommand(null, "desc", 1, 1);

            // Act
            var result = validator.Validate(command);

            // Assert 
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorMessage == "Name is required."));
        }

        [TestMethod]
        public void ShouldHaveErrorWhenDescrptionIsNull()
        {
            // Arrange
            var command = new CreateProductCommand("name", null, 1, 1);

            // Act
            var result = validator.Validate(command);

            // Assert 
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(e => e.ErrorMessage == "Description is required."));
        }
    }
}
