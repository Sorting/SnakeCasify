using System.Globalization;
using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.AspNet.Http;
using Sorting.SnakeCase.Utilities;

namespace Sorting.SnakeCase.Mvc
{
    /// <summary>
    /// An <see cref="IValueProvider"/> adapter for data stored
    /// in a snake cased <see cref="ReadableStringCollectionValueProvider"/>.
    /// </summary>
    public class SnakeCaseQueryValueProvider : ReadableStringCollectionValueProvider, IValueProvider
    {
        public SnakeCaseQueryValueProvider(
            BindingSource bindingSource, 
            IReadableStringCollection values, 
            CultureInfo culture)
            : base(bindingSource, values, culture)
        {
        }

        /// <inheritdoc />
        public override bool ContainsPrefix(string prefix)
        {
            return base.ContainsPrefix(prefix.ToSnakeCase());
        }

        /// <inheritdoc />
        public override ValueProviderResult GetValue(string key)
        {
            return base.GetValue(key.ToSnakeCase());
        }
    }
}
