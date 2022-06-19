using CSharp.Language.Features.V7.Constants;
using CSharp.Language.Features.V7.Models;
using CSharp.Language.Features.V7.UtilityDemo;
using System;
using System.Threading.Tasks;

namespace CSharp.Language.Features.V7.FeatureSnippetRunner
{
    /// <summary>
    /// Class type containing execution methods for C# V7 feature snippets.
    /// </summary>
    internal sealed class CSharpFeatureSnippetRunnerV7
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpFeatureSnippetRunnerV7"/> class.
        /// </summary>
        internal CSharpFeatureSnippetRunnerV7()
        {
            Console.WriteLine($"C# 7 Feature Snippets{Environment.NewLine}{TextConstant.FeatureVersionSeparator}");
        }

        /// <summary>
        /// Executes demo code showing deconstruction mechanics in C# V7.
        /// </summary>
        internal void ExecuteDeconstructionFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Deconstruction Mechanics Snippet {Environment.NewLine}{TextConstant.Separator}");

            // Obviously, deconstruction works very well in tandem with tuple syntax
            var bumblebee = (name: "Stevie Bee", age: 1, size: 15);
            var (name, age, size) = bumblebee;
            Console.WriteLine($"Bumblebee: Name = {name}, Age = {age}, Size = {size}");

            // Deconstruction is not limited to tuples, however. Any of your types can support deconstruction, as follows
            Point testPoint = new Point() { X = 2, Y = 3 };

            // Requires a 'Deconstruct' method (return type void)
            var (x, y) = testPoint;
            Console.WriteLine($"testPoint: x = {x}, y = {y}");

            // You can happily use 'discards' also if you don't need certain values
            var (x1, _) = testPoint;
            Console.WriteLine($"x1 = {x1}");
        }

        /// <summary>
        /// Executes demo code showing local function syntax changes in C# V7 (using the <see cref="EquationSolver"/> type).
        /// </summary>
        internal void ExecuteExpressionBodiedMemberChangesFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Expression Bodied Member Changes Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            // Utilise the test 'Person' type to demonstrate the changes
            Person testPerson = new Person(1, "Steve Jones");

            // Show person details before changes
            Console.WriteLine($"testPerson.Name (testId): {testPerson.Name}");
            Console.WriteLine($"testPerson.Id (testId): {testPerson.TestId}");

            // Change name and inspect (rigged to the testId behind the scenes, but just for illustration - not meaningful code)
            testPerson.Name = "Barry Johnson";

            // Reinspect the name
            Console.WriteLine($"testPerson.Name (testId): {testPerson.Name}");
        }

        /// <summary>
        /// Executes demo code showing literal improvements in C# V7.
        /// </summary>
        internal void ExecuteLiteralImprovementsFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Literal Improvements Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            // Small improvements to literals for numeric types, as follows (makes reading these less cumbersome) - useful for delimiting
            int oneMillionLiteral = 1_000_000;

            // The position of the underscores can be positioned where you like and you can have as many as you like (should you want to)
            int numberOneLiteral = 129_9_21,
                numberTwoLiteral = 129__321_____999;

            // Underscores ignored by the compiler

            // Trailing underscores are a 'nope' of course
            //int trailingUnderscores = 150_000___;

            // Works for hex/binary
            long hexLiteral = 0xFF_FF_FF_FF;
            int binaryLiteral = 0b_0010_1010;

            // Inspect the values of the defined literals
            Console.WriteLine($"oneMillionLiteral = {oneMillionLiteral}");
            Console.WriteLine($"numberOneLiteral = {numberOneLiteral}");
            Console.WriteLine($"numberTwoLiteral = {numberTwoLiteral}");
            Console.WriteLine($"hexLiteral = {hexLiteral}");
            Console.WriteLine($"binaryLiteral = {binaryLiteral}");
        }

        /// <summary>
        /// Executes demo code showing local function syntax changes in C# V7 (using the <see cref="EquationSolver"/> type).
        /// </summary>
        internal void ExecuteLocalFunctionChangesFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Local Function Changes Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            // Create and use an 'EquationSolver' utilising the same arguments each time
            EquationSolver testEquationSolver = new EquationSolver();

            double a = 1, b = 10, c = 16;
            Console.WriteLine($"SolveQuadraticClassicLocalFunctionSyntax result: {testEquationSolver.SolveQuadraticClassicLocalFunctionSyntax(a, b, c)}");
            Console.WriteLine($"SolveQuadraticNewLocalFunctionSyntaxOne result: {testEquationSolver.SolveQuadraticNewLocalFunctionSyntaxOne(a, b, c)}");
            Console.WriteLine($"SolveQuadraticNewLocalFunctionSyntaxTwo result: {testEquationSolver.SolveQuadraticNewLocalFunctionSyntaxTwo(a, b, c)}");
            Console.WriteLine($"SolveQuadraticNewLocalFunctionSyntaxThree result: {testEquationSolver.SolveQuadraticNewLocalFunctionSyntaxThree(a, b, c)}");
        }

        /// <summary>
        /// Executes demo code showing out variable mechanic changes in C# V7.
        /// </summary>
        internal void ExecuteOutVariableFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Out Variable Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

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
            Console.WriteLine($"{Environment.NewLine}Pattern Matching Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            DisplayShape(new Rectangle
            {
                Height = 20,
                Width = 20
            });
        }

        /// <summary>
        /// Executes demo code showing ref locals feature mechanics in C# V7.
        /// </summary>
        internal void ExecuteRefLocalsFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Ref Locals Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            // References to local variables
            int[] sampleNumbers = { 1, 2, 3 };

            // Pointer, or reference, to a value
            ref int refToSecond = ref sampleNumbers[1];

            var valueOfSecond = refToSecond;
            refToSecond = 123;

            // You cannot re-bind a reference, once assigned at this language version
            // refToSecond = ref numbers[0];

            Console.WriteLine($"sampleNumbers = {string.Join(",", sampleNumbers)}");
            Console.WriteLine($"valueOfSecond = {valueOfSecond}");

            // You can do silly things - it'll persist even if the array element itself is no longer available
            Array.Resize(ref sampleNumbers, 1);
            Console.WriteLine($"refToSecond = {refToSecond}, sampleNumbers array size is {sampleNumbers.Length}");

            // You can continue to manipulate the reference, as expected
            refToSecond = 678;
            Console.WriteLine($"refToSecond = {refToSecond} (after reassignment to 678)");

            // Of course, this will still throw an exception (IndexOutOfRangeException)
            //numbers.SetValue(321, 1);

            // Things could become sour here...property or indexer cannot be passed as an out or ref parameter (so constrained here)
            //List<int> numberList = new List<int> { 1, 2, 3 };
            //ref int second = ref numberList[1];
        }

        /// <summary>
        /// Executes demo code showing ref returns feature mechanics in C# V7.
        /// </summary>
        internal void ExecuteRefReturnsFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Ref Returns Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            int[] sampleNumbers = { 10, 20, 30 };

            // Notice that you must specific 'ref' before the invoked method also.
            ref int refToThirty = ref ByRefSampleDemo.GetIntRefFromArray(sampleNumbers, 30);

            // Manipulate the reference
            refToThirty = 1234;
            Console.WriteLine($"sampleNumbers = {string.Join(",", sampleNumbers)}");

            // You can do quite bizarre things, which are of course legal (to obtain a reference and assign it directly - quite verbose)
            ByRefSampleDemo.GetIntRefFromArray(sampleNumbers, 10) = 9999;
            Console.WriteLine($"sampleNumbers = {string.Join(",", sampleNumbers)}");

            // Next, a sample to get a reference to the minimum of two values
            int valueOne = 1, valueTwo = 2;

            // Note, structuring the statement in this way just gives you a by value return
            int minValue = ByRefSampleDemo.GetMinIntRef(ref valueOne, ref valueTwo);

            // On consumption of the Min method the use of ref is prevalent (a bit contagious). Here, we do get the fully-fledged reference
            ref int minRefOfValue = ref ByRefSampleDemo.GetMinIntRef(ref valueOne, ref valueTwo);
            minRefOfValue = 100;

            // Operate on and show the results (minValue unchanged but minRefOfValue altered)
            Console.WriteLine($"valueOne = {valueOne}");
            Console.WriteLine($"valueTwo = {valueTwo}");
            Console.WriteLine($"minValue = {minValue}");
            Console.WriteLine($"minRefOfValue = {minRefOfValue}");
        }

        /// <summary>
        /// Executes demo code showing throw expression mechanics in C# V7.
        /// </summary>
        internal void ExecuteThrowExpressionFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Throw Expressions Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            try
            {
                Contact contactOne = new Contact(null);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            int bonusPercentage = -1;
            try
            {
                Contact contactTwo = new Contact("Barry");
                contactTwo.CalculateBonus(bonusPercentage);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // As expected, bonusPercentage will, of course, be -1
                Console.WriteLine($"bonusPercentage = {bonusPercentage}");
            }
        }

        /// <summary>
        /// Executes demo code showing tuple syntax changes in C# V7.
        /// </summary>
        internal void ExecuteTupleFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Tuple Syntax Changes Snippet {Environment.NewLine}{TextConstant.Separator}");

            // NOTE: tuples has existed in the BCL as different types with a varying number of parameters
            // This perhaps isn't as good or as flexibility as it could be, for example...
            Tuple<double, double> sumAndProduct = SumAndProduct(2, 5);

            // Limits you to the use of Item1/Item2 (maybe OK for small amounts of values, but is verbose and this issue
            // worsens with further values
            Console.WriteLine($"sumAndProduct: sum = {sumAndProduct.Item1}, product = {sumAndProduct.Item2}");

            // Improved tuple syntax (note the defined field names, for extra clarity - you can still use Item1, Item2, etc. if you want to)...
            var newSumAndProduct = NewSumAndProduct(2, 5);
            Console.WriteLine($"newSumAndProduct: sum = {newSumAndProduct.sum}, product = {newSumAndProduct.product}");

            // Custom field names can be forced, if desired
            (double newSum, double newProduct) newSumAndProduct2 = NewSumAndProduct(2, 5);
            Console.WriteLine($"newSumAndProduct2: newSum = {newSumAndProduct2.newSum}, newProduct = {newSumAndProduct2.newProduct}");

            // Inspection of the type (System.ValueType`2[System.Double, System.Double]) - ValueTuple = allows syntactic sugar!
            // Is possible to use ValueTuple directly but not really that beneficial
            Console.WriteLine($"newSumAndProduct2 Type = {newSumAndProduct2.GetType()}");

            // Full deconstruction is also possible (with type inference)
            var (deconstructedSum, deconstructedProduct) = NewSumAndProduct(2, 5);
            Console.WriteLine($"deconstructedSum = {deconstructedSum}, deconstructedProduct = {deconstructedProduct}");

            // Or without an inference
            (double deconstructedSum2, double deconstructedProduct2) = NewSumAndProduct(2, 5);
            Console.WriteLine($"deconstructedSum2 = {deconstructedSum2}, deconstructedProduct2 = {deconstructedProduct2}");

            // Also legal to declare variables beforehand, like so
            double deconstructedSum3, deconstructedProduct3;
            (deconstructedSum3, deconstructedProduct3) = NewSumAndProduct(2, 5);
            Console.WriteLine($"deconstructedSum3 = {deconstructedSum3}, deconstructedProduct3 = {deconstructedProduct3}");

            // Tuples can be generated with field names inline too
            var person = (name: "Lew", age: 38, address: "1 The Street");
            Console.WriteLine($"person = {person}");
            Console.WriteLine($"Name: {person.name}, Age: {person.age}, Address: {person.address}");
            Console.WriteLine($"person Type = {person.GetType()}");

            // Also, usable in any place where ordinary types are used (to use field names here they must be in the Func signature)
            var testFunc = new Func<double, double, (double sum, double product)>((doubleOne, doubleTwo) => (doubleOne + doubleTwo, doubleOne * doubleTwo));
            var testFuncResult = testFunc(3, 6);
            Console.WriteLine($"testFuncResult: sum = {testFuncResult.sum}, product = {testFuncResult.product}");

            // Syntactic sugar of field names, does this make it to the IL (not just Item1, Item2, etc.)? Answer is both yes/no. Referencing the fields means you
            // are just referencing Item1, Item2, etc. but pieces of a public API that use tuples with field names are preserved (TupleElementNames attribute)
        }

        /// <summary>
        /// Executes demo code showing <see cref="ValueTask"/> mechanics in C# V7.
        /// </summary>
        internal void ExecuteValueTypeFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}ValueTask Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            Task demoValueTypeTask = Task.Run(async () =>
            {
                string targetDirectory = @"C:\temp";

                DirectoryInspector testInspector = new DirectoryInspector();
                long directorySize = await testInspector.GetDirectorySize(targetDirectory),
                    directorySizeWithValueTask = await testInspector.GetDirectorySizeWithValueTask(targetDirectory);

                Console.WriteLine($"directorySize = {directorySize} bytes");
                Console.WriteLine($"directorySizeWithValueTask = {directorySizeWithValueTask} bytes");
            });

            demoValueTypeTask.GetAwaiter().GetResult();
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
                Console.WriteLine($"castRectangle.Height: {castRectangle.Height}");
            }

            // Existing 'as' mechanic (getting null if the cast is unsuccessful)
            Rectangle castAsRectangle = shapeInScope as Rectangle;
            Console.WriteLine(castAsRectangle == null ? "Cast to Rectangle invalid" : $"castAsRectangle.Height: {castAsRectangle.Height}");

            // Use '!' pattern matching in a useful way? (maybe)
            Console.WriteLine(!(shapeInScope is Rectangle castAsRectangle2) ? "Cast to Rectangle invalid" : $"castAsRectangle2.Height: {castAsRectangle2.Height}");

            // Use in a classic if statement
            if (shapeInScope is Rectangle castRectangle3)
            {
                Console.WriteLine($"castRectangle3.Height: {castRectangle3.Height}");
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

        /// <summary>
        /// Private static method that illustrates the use of new Tuple syntax.
        /// For illustration purposes only.
        /// NOTE: Historically required the installation of the 'System.ValueTuple' NuGet package (but no longer so).
        /// </summary>
        /// <param name="firstDouble">The first incoming double value.</param>
        /// <param name="secondDouble">The second incoming double value.</param>
        /// <returns>A tuple type using more concise syntax.</returns>
        private static (double sum, double product) NewSumAndProduct(double firstDouble, double secondDouble) => (firstDouble + secondDouble, firstDouble * secondDouble);

        /// <summary>
        /// Private static method using traditional mechanics to create a <see cref="Tuple"/>.
        /// For illustration purposes only.
        /// </summary>
        /// <param name="firstDouble">The first incoming double value.</param>
        /// <param name="secondDouble">The second incoming double value.</param>
        /// <returns>A <see cref="Tuple"/> containing the sum and product of the two double values provided (for demo purposes only).</returns>
        private static Tuple<double, double> SumAndProduct(double firstDouble, double secondDouble) => Tuple.Create(firstDouble + secondDouble, firstDouble * secondDouble);
    }
}
