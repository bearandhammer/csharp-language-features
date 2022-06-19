using CSharp.Language.Features.V7.Constants;
using System;

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
    }
}
