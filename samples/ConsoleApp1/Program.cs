using Sorting.SnakeCase.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public void Main(string[] args)
        {
            const int Iterations = 100000;
            var value = "CustomerADDRInformation";

            long ourTime = 0,
                regexTime = 0,
                lambdaTime = 0;

            var sw = new Stopwatch();

            var result = string.Empty;

            sw.Start();
            for (int i = 0; i < Iterations; i++)
            {
                result = value.ToSnakeCase();
            }
            sw.Stop();

            ourTime = sw.ElapsedMilliseconds;

            Console.WriteLine(result);
            Console.WriteLine(ourTime + " ms \n\n");

            sw.Restart();
            for (int i = 0; i < Iterations; i++)
            {
                result = string.Concat(value.Select((x, j) => j > 0 && char.IsUpper(x) ? "_" + x.ToString().ToLowerInvariant() : x.ToString().ToLowerInvariant()));
            }
            sw.Stop();

            lambdaTime = sw.ElapsedMilliseconds;

            Console.WriteLine(result);
            Console.WriteLine(lambdaTime + " ms \n\n");

#if DNX451
            sw.Restart();
            for (int i = 0; i < Iterations; i++)
            {
                result = System.Text.RegularExpressions.Regex.Replace(value, "(?<=.)([A-Z])", "_$0",
                        System.Text.RegularExpressions.RegexOptions.Compiled);
            }
            sw.Stop();

            regexTime = sw.ElapsedMilliseconds;

            Console.WriteLine(result);
            Console.WriteLine(regexTime+ " ms \n\n");
#endif

            Console.WriteLine("Our algorithm is {0:0}% faster than lambda, and {1:0}% faster then regex. This when iterating {2:0 000} times.", 
                100 - Math.Ceiling((((decimal)ourTime / (decimal)lambdaTime) * 100)), 
                100 - Math.Ceiling(((decimal)ourTime / (decimal)regexTime) * 100),
                Iterations);
        }
    }
}
