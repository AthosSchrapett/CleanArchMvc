using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeValue_ResultObjectValidState()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id Value.");
        }

        [Fact]
        public void CreateCategory_WithShortNameValue_ResultObjectValidState()
        {
            Action action = () => new Category(1, "ca");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 charecters.");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_ResultObjectValidState()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name.Name is required.");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_ResultObjectValidState()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>();
        }
    }
}
