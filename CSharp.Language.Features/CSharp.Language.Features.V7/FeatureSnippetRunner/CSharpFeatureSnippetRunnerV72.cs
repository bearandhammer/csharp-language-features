using CSharp.Language.Features.V7.Constants;
using System;

namespace CSharp.Language.Features.V7.FeatureSnippetRunner
{
    /// <summary>
    /// Class type containing execution methods for C# V7.2 feature snippets.
    /// </summary>
    internal sealed class CSharpFeatureSnippetRunnerV72
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpFeatureSnippetRunnerV71"/> class.
        /// </summary>
        internal CSharpFeatureSnippetRunnerV72()
        {
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}C# 7.2 Feature Snippets{Environment.NewLine}{TextConstant.FeatureVersionSeparator}");
        }

        /// <summary>
        /// Executes demo code showing usage of leading digit separators in C# V7.2.
        /// </summary>
        internal void ExecuteLeadingDigitSeparatorsFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Leading Digit Separators Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            // Add leading underscores to binary/hexidecimal separators

            // Example, which would have been an issue before (couldn't have added an underscore after 0b). Binary...
            var sampleOne = 0b_1111_0000;

            // Hexidecimal...
            var sampleTwo = 0x_baad_d00d;

            // Still cannot do leading underscores (doesn't make too much sense to do so)
            // var sampleThree = _100_000;

            Console.WriteLine($"sampleOne = {sampleOne}");
            Console.WriteLine($"sampleTwo = {sampleTwo}");
        }
    }
}
