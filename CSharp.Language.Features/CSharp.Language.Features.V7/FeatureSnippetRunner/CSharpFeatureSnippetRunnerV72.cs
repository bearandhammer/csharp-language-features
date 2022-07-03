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
        }
    }
}
