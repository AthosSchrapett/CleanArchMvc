using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{

    public class ProductUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParams_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Product Image");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeValue_ResultObjectValidState()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "Product Image");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("invalid Id value");
        }

        [Fact]
        public void CreateCategory_WithShortNameValue_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "Product Image");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_ResultObjectValidState()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "Product Image");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateCategory_WithShortDescriptionValue_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Prod", 9.99m, 99, "Product Image");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters");
        }

        [Fact]
        public void CreateCategory_MissingDescriptionValue_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "", 9.99m, 99, "Product Image");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact]
        public void CreateCategory_LongImageName_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, 
                "Lorem ipsum dolor sit amet consectetur adipisicing elit. Soluta atque cupiditate dolore commodi? Expedita officia sint, neque, possimus pariatur distinctio velit iure, excepturi dolores magni magnam mollitia laboriosam quis quaerat similique blanditiis quam enim! Eos laudantium sint odit obcaecati. Modi earum culpa laboriosam eveniet iure ipsum iusto doloremque facere. Cupiditate, error atque. Est odit repellendus, dolores consequuntur molestias minima beatae reiciendis, accusamus voluptates quisquam libero dignissimos eius cumque nihil perferendis sed alias! Molestias accusantium dolor soluta quia aperiam sit quasi, dicta reprehenderit unde sed voluptates asperiores libero maxime accusamus laboriosam iure maiores ipsam perspiciatis eum! Quos quis exercitationem, blanditiis, non laborum, facilis vero ex enim atque odio commodi pariatur? Ratione minima quia est voluptatem. Id, maxime unde culpa eos accusamus veniam dolor laboriosam perspiciatis et quia saepe incidunt nobis corporis? Dicta delectus placeat distinctio at! Doloribus dolores eos praesentium cupiditate, at facilis nam rerum consequatur? Eos, voluptas vel laborum deleniti culpa facilis vero nisi ea libero reprehenderit hic voluptatem perspiciatis quidem atque eum rem exercitationem ratione et labore. Quo, impedit dolorem sit consequuntur distinctio temporibus eligendi fugit voluptate minus provident assumenda enim commodi magni sequi repellendus reiciendis esse iure beatae veritatis omnis, cupiditate officia saepe reprehenderit minima? Rem minima esse deserunt libero optio eius, aliquid reprehenderit quos minus odio voluptates, exercitationem ab iure! Cupiditate assumenda ipsa qui ad quae facere reiciendis aspernatur voluptatibus minus? Ducimus repudiandae vero aut libero tenetur, beatae incidunt neque voluptatem accusantium suscipit magni unde totam, amet adipisci harum repellat minima, placeat minus molestiae. Quas quaerat autem quia");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact]
        public void CreateCategory_WithNullImageName_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_WithEmptyImageName_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_InvalidPriceValue_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 99, "Product Image");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateCategory_InvalidStockValue_ResultObjectValidState(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, value, "Product Image");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }
    }
}
