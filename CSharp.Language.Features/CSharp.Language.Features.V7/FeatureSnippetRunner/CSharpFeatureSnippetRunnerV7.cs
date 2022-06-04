using CSharp.Language.Features.V7.Constants;
using CSharp.Language.Features.V7.Models;
using System;

namespace CSharp.Language.Features.V7.FeatureSnippetRunner
{
    /// <summary>
    /// Class type containing execution methods for C# V7 feature snippets.
    /// </summary>
    internal class CSharpFeatureSnippetRunnerV7
    {
        /// <summary>
        /// Executes demo code showing out variable mechanic changes in C# V7.
        /// </summary>
        internal void ExecuteOutVariableFeatureSnippet()
        {
            Console.WriteLine($"Out Variable Feature Snippet {Environment.NewLine}{ TextConstant.Separator }");

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

        /// <summary>
        /// Executes demo code showing pattern matching mechanic changes in C# V7.
        /// </summary>
        internal void ExecutePatternMatchingFeatureSnippet()
        {
            Console.WriteLine($"{ Environment.NewLine }Pattern Matching Feature Snippet { Environment.NewLine }{ TextConstant.Separator }");

            DisplayShape(new Rectangle
            {
                Height = 20,
                Width = 20
            });
        }
        
        /// <summary>
        /// Demo utility method responsible for displaying a shape.
        /// </summary>
        /// <param name="shapeInScope">The current <see cref="Shape"/> to operate against.</param>
        private static void DisplayShape(Shape shapeInScope)
        {
            // Existing 'is' mechanic to check type before casting
            if (shapeInScope is Rectangle)
            {
                Rectangle castRectangle = (Rectangle)shapeInScope;
                Console.WriteLine($"castRectangle.Height: { castRectangle.Height }");
            }

            // Existing 'as' mechanic (getting null if the cast is unsuccessful)
            Rectangle castAsRectangle = shapeInScope as Rectangle;
            Console.WriteLine(castAsRectangle == null ? "Cast to Rectangle invalid" : $"castAsRectangle.Height: { castAsRectangle.Height }");

            // Use '!' pattern matching in a useful way? (maybe)
            Console.WriteLine(!(shapeInScope is Rectangle castAsRectangle2) ? "Cast to Rectangle invalid" : $"castAsRectangle2.Height: { castAsRectangle2.Height }");

            // Use in a classic if statement
            if (shapeInScope is Rectangle castRectangle3)
            {
                Console.WriteLine($"castRectangle3.Height: { castRectangle3.Height }");
            }

            // Also useful in a traditional switch
            switch (shapeInScope)
            {
                // Cast and directly use the variable result as part of the match process
                case Circle castCircleInSwitch:
                    castCircleInSwitch.SayHello();
                    break;
                // Additional use of the 'when' to match facets of the cast result
                case Rectangle castRectangleInSwitch when castRectangleInSwitch.Height == castRectangleInSwitch.Width:
                    Console.WriteLine("castRectangleInSwitch is a square.");
                    break;
                default:
                    break;
            }

            // Switching on tuples...not available at this stage in feature lifecycle (is in F#)
        }
    }
}
