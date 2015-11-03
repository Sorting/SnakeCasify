using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.ModelBinding;
using System.Globalization;

namespace Sorting.SnakeCase.Mvc
{
    /// <summary>
    /// A <see cref="IValueProviderFactory" that creates a <see cref="SnakeCaseQueryValueProvider" instance that />/>
    /// reads values from the request query-string.
    /// </summary>
    public class SnakeCaseQueryValueProviderFactory : IValueProviderFactory
    {
        /// <inheritdoc />
        public Task<IValueProvider> GetValueProviderAsync(ValueProviderFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return Task.FromResult<IValueProvider>(new SnakeCaseQueryValueProvider(
                BindingSource.Query,
                context.HttpContext.Request.Query,
                CultureInfo.InvariantCulture));
        }
    }
}
