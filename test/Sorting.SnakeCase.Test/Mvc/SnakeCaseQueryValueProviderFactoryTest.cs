#if DNX451
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.AspNet.Http;
using Moq;
using Sorting.SnakeCase.Mvc;
using Xunit;

namespace Sorting.SnakeCase.Test.Mvc
{
    public class SnakeCaseQueryValueProviderFactoryTest
    {
        private readonly SnakeCaseQueryValueProviderFactory _factory = new SnakeCaseQueryValueProviderFactory();

        [Fact]
        public async Task GetValueProvider_ReturnsSnakeCaseQueryValueProviderInstanceWithInvariantCulture()
        {
            // Arrange
            var request = new Mock<HttpRequest>();

            request.SetupGet(f => f.Query).Returns(Mock.Of<IReadableStringCollection>());

            var context = new Mock<HttpContext>();

            context.SetupGet(c => c.Items).Returns(new Dictionary<object, object>());
            context.SetupGet(c => c.Request).Returns(request.Object);

            var factoryContext = new ValueProviderFactoryContext(
                context.Object,
                new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase));

            // Act
            var result = await _factory.GetValueProviderAsync(factoryContext);

            // Assert
            var valueProvider = Assert.IsType<SnakeCaseQueryValueProvider>(result);
            Assert.Equal(CultureInfo.InvariantCulture, valueProvider.Culture);
        }
    }
}
#endif