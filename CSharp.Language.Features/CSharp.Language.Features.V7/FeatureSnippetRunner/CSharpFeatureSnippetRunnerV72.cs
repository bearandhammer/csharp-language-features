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
        /// Executes demo code showing how the in parameter functions in C# V7.2 (reference semantics to value types).
        /// </summary>
        internal void ExecuteInParameterFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}In Parameter Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            // Create some sample points
            PointStruct point1 = new PointStruct(1, 1),
                point2 = new PointStruct(4, 5);

            // Measure distance providing point structs by reference (rather than copying structs)
            double distance = MeasureDistanceBetweenPoints(point1, point2);
            Console.WriteLine($"Distance between {point1} and {point2} is {distance}.");

            // Nothing prevents calling a method with an in parameter with a newly constructed object - still legal
            double distanceFromOrigin = MeasureDistanceBetweenPoints(point1, new PointStruct());
            Console.WriteLine($"distanceFromOrigin = {distanceFromOrigin}");
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
            Console.WriteLine($"bValue = {bValue}.");

            // Create a derived type (this assembly) to illustrate access modifiers further (can access 'a' and 'b')
            PrivateProtectedSampleDerived sampleDerived = new PrivateProtectedSampleDerived();
            sampleDerived.IllustrateAccessToFields();

            // Also fine
            int derivedBValue = sampleDerived.b;
            Console.WriteLine($"derivedBValue = {derivedBValue}.");

            // But, of course, this will trip up private protected (not from a derived class, although same assembly)
            //int derivedCValue = sampleDerived.c;
        }

        /// <summary>
        /// Sample demo method that increments the X value of a <see cref="PointStruct"/>.
        /// </summary>
        /// <param name="point">The point to modify.</param>
        private static void IncrementPointXValue(ref PointStruct point) => point.X++;

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

        /// <summary>
        /// Measures the distance between the supplied <see cref="PointStruct"/> types. The 'in' keyword
        /// specifies that the structures will be provided by reference, not value (not an entire copy).
        /// NOTES:
        /// 1. The in keyword makes the struct 'readonly' (it is immutable).
        /// 2. You cannot create an overload of the method where the signature differs by the in keyword only (well, it will compile, but you just want be able to call the 'in' parameter variant - used to cause ambigious errors).
        /// </summary>
        /// <param name="point1">The first point.</param>
        /// <param name="point2">The second point.</param>
        /// <returns>A <see cref="double"/> representing the difference between two points.</returns>
        private double MeasureDistanceBetweenPoints(in PointStruct point1, in PointStruct point2)
        {
            // In keyword makes parameters readonly, so modifications are not possible:
            //point1 = new PointStruct(1, 2);
            //IncrementPointXValue(ref point1);

            // You do get interesting behaviour if you call a mutation on a point, however. This mutation
            // attempts to reset X and Y to zero on one of the supplied points (which is allowed and compiles)...
            point1.Reset();

            // Post reset, nothing changes. The reason...Reset is called on a by value copy (of the memory for point1)!

            double differenceX = point1.X - point2.X,
                differenceY = point1.Y - point2.Y;

            return Math.Sqrt(differenceX * differenceX + differenceY * differenceY);
        }

        // Uncomment this to see the 'in' keyword variant get sidelined!
        //private double MeasureDistanceBetweenPoints(PointStruct point1, PointStruct point2) => 0.0;
    }
}
