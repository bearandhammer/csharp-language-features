using System;

namespace CSharp.Language.Features.V7.FeatureSnippetRunner
{
    /// <summary>
    /// Class type containing execution methods for C# V7 feature snippets.
    /// </summary>
    internal class CSharpFeatureSnippetRunnerV7
    {
        /// <summary>
        /// Represents a string separator for section titles (when snippets are executed).
        /// </summary>
        private const string Separator = "------------------------------------";

        /// <summary>
        /// Executes demo code showing out variable mechanic changes in C# V7.
        /// </summary>
        internal void ExecuteOutVariableFeatureSnippet()
        {
            Console.WriteLine($"Out Variable Feature Snippet {Environment.NewLine}{ Separator }");

            // Old out variable mechanic, requiring explicit/separate variable declaration
            DateTime test1DateTime;
            if (DateTime.TryParse("04/04/2022", out test1DateTime))
            {
                Console.WriteLine($"test1DateTime: {test1DateTime}");
            }

            // Can now declare the variable inline
            if (DateTime.TryParse("05/04/2022", out DateTime test2DateTime))
            {
                Console.WriteLine($"test2DateTime: {test2DateTime}");
            }

            // Variable can be used outside the scope of if (where out was utilised)
            Console.WriteLine($"test2DateTime.Year: {test2DateTime.Year}");

            // Var can be used, as expected
            bool doubleParseSuccessful = double.TryParse("122.55", out var parsedResult);
            Console.WriteLine($"doubleParseSuccessful: {doubleParseSuccessful}");
            Console.WriteLine($"parsedResult: {parsedResult}");
        }
    }
}
