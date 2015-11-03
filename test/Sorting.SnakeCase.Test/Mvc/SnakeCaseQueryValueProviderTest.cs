using Sorting.SnakeCase.Mvc;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.AspNet.Http.Internal;
using Microsoft.Framework.Primitives;
using Xunit;

namespace Sorting.SnakeCase.Test.Mvc
{
    public class SnakeCaseQueryValueProviderTest
    {
        [Theory]
        [InlineData("my_query_param", "myQueryParam")]
        [InlineData("my_second_query_param", "mySecondQueryParam")]
        public void ContainsPrefix_ReturnsTrue_IfQueryStringNameStartsWithPrefix(
            string expectedKey,
            string key)
        {
            // Arrange
            var bindingSource = BindingSource.Query;
            var culture = new CultureInfo("en-US");

            var collection = new ReadableStringCollection(
                    new Dictionary<string, StringValues>() {
                        { expectedKey, new StringValues("value") }
                    });

            // Act
            var valueProvider = 
                new SnakeCaseQueryValueProvider(
                    bindingSource, 
                    collection, 
                    culture);

            // Assert
            Assert.True(valueProvider.ContainsPrefix(key));
        }
    }
}