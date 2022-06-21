using CSharp.Language.Features.V7.Constants;
using CSharp.Language.Features.V7.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharp.Language.Features.V7.FeatureSnippetRunner
{
    /// <summary>
    /// Class type containing execution methods for C# V7.1 feature snippets.
    /// </summary>
    internal sealed class CSharpFeatureSnippetRunnerV71
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpFeatureSnippetRunnerV71"/> class.
        /// </summary>
        internal CSharpFeatureSnippetRunnerV71()
        {
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}C# 7.1 Feature Snippets{Environment.NewLine}{TextConstant.FeatureVersionSeparator}");
        }

        /// <summary>
        /// Executes demo code showing usage of default expression changes in C# V7.1.
        /// </summary>
        internal void ExecuteDefaultExpressionChangesFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Default Expression Changes Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            // Literal - keyword which represents a particular value. Default literals

            // Older mechanic - use of the default keyword specifying the type (ValueTypes, 0 or false for example or null for reference types)
            int sampleNumber = default(int);
            Person samplePerson = default(Person);

            Console.WriteLine($"sampleNumber = {sampleNumber}");
            Console.WriteLine($"samplePerson {(samplePerson != null ? "is not null" : "is null")}");

            // Simplify default expression (default literal) - inferred by compiler from the context
            int sampleNumberTwo = default;

            // Can be used with constants (0 forever in this case)
            const int sampleConstantNumber = default;

            // Nullable const is a no go, as you would expect
            //const int? nullableSampleConstantNumber = default;

            // Normal nullable, fine - default null
            int? nullableSampleNumber = default;

            Console.WriteLine($"sampleNumberTwo = {sampleNumberTwo}");
            Console.WriteLine($"sampleConstantNumber = {sampleConstantNumber}");
            Console.WriteLine($"nullableSampleNumber {(nullableSampleNumber.HasValue ? "is not null" : "is null")}");
        }

        /// <summary>
        /// Executes demo code showing usage of an overaching async Main method in C# V7.1.
        /// </summary>
        internal async Task ExecuteUtiliseAsyncMainFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Utilise Async Main Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            // Demo only - retrieve robots.txt content from google using an async API
            using (HttpClient client = new HttpClient())
            {
                string robotsTxtContent = await client.GetStringAsync("https://google.com/robots.txt");

                if (!string.IsNullOrWhiteSpace(robotsTxtContent))
                {
                    string topFiveRobotsTxtLines = string.Join(",", robotsTxtContent.Split("\n").ToList().GetRange(0, 5));
                    Console.WriteLine($"topFiveRobotsTxtLines = {topFiveRobotsTxtLines}");
                }
            }
        }
    }
}
