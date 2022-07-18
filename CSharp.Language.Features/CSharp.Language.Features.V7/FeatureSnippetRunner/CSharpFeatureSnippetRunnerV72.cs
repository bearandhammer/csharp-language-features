using CSharp.Language.Features.V7.Constants;
using CSharp.Language.Features.V7.Models;
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

        /// <summary>
        /// Executes demo code showing how the ability to provide named arguments to methods has changed in C# V7.2.
        /// </summary>
        internal void ExecuteNamedArgumentsChangesFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Named Argument Changes Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            // Previous functionality, named arguments always have to trail the rest of the arguments...
            NamedArgumentsTestMethod(55, arg2: 105);

            // You still have to be conscious of ordering but you can now use named arguments in a non-trailing way...
            NamedArgumentsTestMethod(arg1: 105, 155);

            // Still invalid to contradict ordering, however
            //NamedArgumentsTestMethod(65, arg1: 78);

            // And fine, as always, to specify all arguments
            NamedArgumentsTestMethod(arg1: 99, arg2: 100);
        }

        /// <summary>
        /// Executes demo code showing how the 'private protected' modifier functions in C# V7.2.
        /// This demo pairs with other sample code in CSharp.Language.Features.PrivateProtected.
        /// </summary>
        internal void ExecutePrivateProtectedAccessModifierFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Private Protected Access Modifier Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            // Illustrate existing access modifiers (for comparison purposes)
            PrivateProtectedSampleBase sampleBase = new PrivateProtectedSampleBase();

            // Private - of course, innaccesible
            //int aValue = sampleBase.a;

            // Protected internal - can access (same assembly)
            int bValue = sampleBase.b;
            Console.WriteLine($"bValue = {bValue}");

            // Create a derived type (this assembly) to illustrate access modifiers further (can access 'a' and 'b')
            PrivateProtectedSampleDerived sampleDerived = new PrivateProtectedSampleDerived();
            sampleDerived.IllustrateAccessToFields();

            // Also fine
            int derivedBValue = sampleDerived.b;
            Console.WriteLine($"derivedBValue = {derivedBValue}");

            // But, of course, this will trip up private protected (not from a derived class, although same assembly)
            //int derivedCValue = sampleDerived.c;
        }

        /// <summary>
        /// Executes demo code showing how the in parameter functions in C# V7.2 (reference semantics to value types).
        /// </summary>
        internal void ExecuteInParameterFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}In Parameter Feature Snippet {Environment.NewLine}{TextConstant.Separator}");
        }

        /// <summary>
        /// Private static test method for use when illustrating named argument changes.
        /// </summary>
        /// <param name="arg1">Sample argument 1.</param>
        /// <param name="arg2">Sample argument 2.</param>
        private static void NamedArgumentsTestMethod(int arg1, int arg2)
        {
            Console.WriteLine($"arg1 = {arg1}");
            Console.WriteLine($"arg2 = {arg2}");
        }
    }
}
