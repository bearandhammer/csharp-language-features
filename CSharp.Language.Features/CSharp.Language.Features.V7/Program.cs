using CSharp.Language.Features.V7.FeatureSnippetRunner;
using System.Threading.Tasks;

namespace CSharp.Language.Features.V7
{
    /// <summary>
    /// <see cref="Program"/> class for V7.x feature snippets.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Private static method that creates a <see cref="CSharpFeatureSnippetRunnerV71"/> type
        /// and executes feature snippets (pushing results to the console).
        /// </summary>
        private static async Task ExecuteVersion71Snippets()
        {
            CSharpFeatureSnippetRunnerV71 featureSnippetRunner = new CSharpFeatureSnippetRunnerV71();

            // Execute snippets to explore features
            await featureSnippetRunner.ExecuteUtiliseAsyncMainFeatureSnippet();
            featureSnippetRunner.ExecuteDefaultExpressionChangesFeatureSnippet();
            featureSnippetRunner.ExecuteInferredTupleNamesFeatureSnippet();
            featureSnippetRunner.ExecutePatternMatchingWithGenericsFeatureSnippet();
        }

        #region V7.1 Async Main Signatures

        // Signature can take the form of:
        // async Task / Task<int>
        // void/int
        // string[] args/ ()
        // NOTE: One annoyance - at this 'version' Visual Studio does not index async Main methods as an entry point (which is problematic if other objects define a Main method - one to be aware of
        // as this would mean you need to rename the other Main methods temporarily)

        #endregion V7.1 Async Main Signatures

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
        private static async Task Main()
        {
            ExecuteVersion7Snippets();
            await ExecuteVersion71Snippets();
        }
    }
}
