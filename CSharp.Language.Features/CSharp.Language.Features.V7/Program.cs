using CSharp.Language.Features.V7.FeatureSnippetRunner;

namespace CSharp.Language.Features.V7
{
    /// <summary>
    /// <see cref="Program"/> class for V7.x feature snippets.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Private static method that creates a <see cref="CSharpFeatureSnippetRunnerV7"/> type
        /// and executes feature snippets (pushing results to the console).
        /// </summary>
        private static void ExecuteVersion7Snippets()
        {
            CSharpFeatureSnippetRunnerV7 featureSnippetRunner = new CSharpFeatureSnippetRunnerV7();

            // Execute snippets to explore features
            featureSnippetRunner.ExecuteOutVariableFeatureSnippet();
            featureSnippetRunner.ExecutePatternMatchingFeatureSnippet();
            featureSnippetRunner.ExecuteTupleFeatureSnippet();
            featureSnippetRunner.ExecuteDeconstructionFeatureSnippet();
            featureSnippetRunner.ExecuteLocalFunctionChangesFeatureSnippet();
            featureSnippetRunner.ExecuteRefLocalsFeatureSnippet();
            featureSnippetRunner.ExecuteRefReturnsFeatureSnippet();
            featureSnippetRunner.ExecuteExpressionBodiedMemberChangesFeatureSnippet();
            featureSnippetRunner.ExecuteThrowExpressionFeatureSnippet();
            featureSnippetRunner.ExecuteValueTypeFeatureSnippet();
            featureSnippetRunner.ExecuteLiteralImprovementsFeatureSnippet();
        }

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        private static void Main()
        {
            ExecuteVersion7Snippets();
        }
    }
}
