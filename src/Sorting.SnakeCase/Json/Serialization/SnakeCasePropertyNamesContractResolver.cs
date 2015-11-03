using System;
using Newtonsoft.Json.Serialization;
using Sorting.SnakeCase.Utilities;

namespace Sorting.SnakeCase.Json.Serialization
{
    public class SnakeCasePropertyNamesContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            return propertyName.ToSnakeCase();
        }
    }
}
