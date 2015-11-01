using System.Text;

namespace Sorting.SnakeCase.Utilities
{
    /// <summary>
    /// Snake case extension methods for <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns a copy of the string converted to snake case
        /// </summary>        
        public static string ToSnakeCase(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return s;
            }
            s.ToLower();
            int length = s.Length,
                latestTrailingUcaseIndex = -1,
                addedUnderscores = 0;

            var stringBuilder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var currentChar = s[i];

                if (char.IsUpper(currentChar))
                {
                    bool isLastChar = ((i + 1) == length),
                        isFirstChar = (i == 0),
                        prevCharIsUpper = false,
                        prevCharIsLower = false, 
                        nextCharIsLower = false;

                    if (!isFirstChar)
                    {
                        var prevChar = s[i - 1];

                        prevCharIsUpper = (char.IsUpper(prevChar));
                        prevCharIsLower = (char.IsLower(prevChar));
                    }

                    if (!isLastChar)
                    {
                        nextCharIsLower = (char.IsLower(s[i + 1]));
                    }

                    var isLastCharInTrailingUcaseSeries = 
                        (prevCharIsUpper && (nextCharIsLower || isLastChar));

                    if ((isFirstChar || prevCharIsLower) 
                        && latestTrailingUcaseIndex == -1)
                    {
                        latestTrailingUcaseIndex = i;
                    }

                    if (isLastCharInTrailingUcaseSeries 
                        && latestTrailingUcaseIndex > 0)
                    {
                        stringBuilder.Insert(latestTrailingUcaseIndex + addedUnderscores, '_');
                        addedUnderscores++;
                    }

                    if (!isFirstChar && nextCharIsLower)
                    {
                        stringBuilder.Append('_');
                        addedUnderscores++;
                    }

                    stringBuilder.Append(char.ToLower(currentChar));
                    continue;
                }

                latestTrailingUcaseIndex = -1;
                stringBuilder.Append(currentChar);
            }

            return stringBuilder.ToString();
        }
    }
}