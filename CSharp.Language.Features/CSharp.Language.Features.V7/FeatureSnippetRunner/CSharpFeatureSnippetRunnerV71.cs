using CSharp.Language.Features.V7.Constants;
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
        /// Executes demo code showing usage of an overaching async Main method in C# V7.1.
        /// </summary>
        internal async Task ExecuteUtiliseAsyncMainFeatureSnippet()
        {
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

        // Literal - keyword which represents a particular value. Default literals
    }
}
