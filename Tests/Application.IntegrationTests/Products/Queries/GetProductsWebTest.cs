using CleanArch.Application.Products.Queries.GetAllProductsWeb;
using CleanArch.Domain.Entities.CategoryAggregation;
using CleanArch.Domain.Entities.ProductAggregation;
using FluentAssertions;
using Namotion.Reflection;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Products.Queries
{
    using static Testing;
    public class GetProductsWebTest : TestBase
    {
        [Test]
        public async Task ShouldReturnOneProductWithCategory()
        {
            var categoryId = await AddAsync(new Category("GetProductsWebTestCategory"));
            await AddAsync(new Product("GetProductsWebTest", "Test", null, 1500, 0, categoryId));

            var query = new GetAllProductsWebQuery();
            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.List.Should().HaveCount(1);
            result.Count.Should().Be(1);
            result.PageSize.Should().Be(10);
            result.List.First().Name.Should().NotBeNullOrWhiteSpace();
            result.List.First().Description.Should().NotBeNullOrWhiteSpace();
            result.List.First().Category.Should().NotBeNullOrWhiteSpace();
            result.List.First().Price.Should().BePositive();
        }
    }
}
