using CSharp.Language.Features.V7.Constants;
using CSharp.Language.Features.V7.Models;
using CSharp.Language.Features.V7.UtilityDemo;
using System;
using System.Collections.Generic;

namespace CSharp.Language.Features.V7.FeatureSnippetRunner
{
    /// <summary>
    /// Class type containing execution methods for C# V7 feature snippets.
    /// </summary>
    internal class CSharpFeatureSnippetRunnerV7
    {
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
            Console.WriteLine($"x1 = {x}");
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
            Console.WriteLine($"Out Variable Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

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

        internal void Test()
        {
            #region Example One

            // References to local variables
            int[] numbers = { 1, 2, 3 };

            // Pointer, or reference, to a value
            ref int refToSecond = ref numbers[1];

            var valueOfSecond = refToSecond;
            refToSecond = 123;

            // You cannot re-bind a reference, once assigned at this language version
            // refToSecond = ref numbers[0];

            Console.WriteLine(string.Join(",", numbers));

            #endregion Example One

            #region Example Two

            // You can do silly things - it'll persist even if the array element itself is no longer available
            Array.Resize(ref numbers, 1);
            Console.WriteLine($"second = { refToSecond }, array size is { numbers.Length }");

            // You can continue to manipulate the reference, as expected
            refToSecond = 678;
            Console.WriteLine($"second = {refToSecond}");

            // Of course, this will still throw an exception (IndexOutOfRangeException)
            //numbers.SetValue(321, 1);

            #endregion Example Two

            #region Example Three

            // Things could become sour here...property or indexer cannot be passed as an out or ref parameter (so constrained here)
            //List<int> numberList = new List<int> { 1, 2, 3 };
            //ref int second = ref numberList[1];

            #endregion Example Three
        }

        internal void Test2()
        {
            int[] moreNumbers = { 10, 20, 30 };

            // Notice that you must specific 'ref' before the invoked method also.
            ref int refToThirty = ref Find(moreNumbers, 30);

            // Manipulate the reference
            refToThirty = 1234;

            Console.WriteLine(String.Join(",", moreNumbers));

            // You can do quite bizarre things, which are of course legal (to obtain a reference and assign it directly - quite verbose)
            Find(moreNumbers, 10) = 9999;

            Console.WriteLine(String.Join(",", moreNumbers));
        }

        internal void Test3()
        {
            int a = 1, b = 2;

            // Note, structuring the statement in this way just gives you a by value return
            int valueMinValue = Min(ref a, ref b);

            // On consumption of the Min method the use of ref is prevalent (a bit contagious). Here, we do get the fully-fledged reference
            ref int minValue = ref Min(ref a, ref b);

        }

        static ref int Find(int[] numbers, int value)
        {
            for (int index = 0; index < numbers.Length; index++)
            {
                if (numbers[index] == value)
                {
                    // Using a reference in the return statement...
                    return ref numbers[index];
                }
            }

            // What do you return in this case...you would normally return -1 or 0, for example, but we need a 'ref'...
            // return -1; //Won't work

            // Also, you can't trick the compiler
            //int fail = -1;
            //return ref fail;

            throw new ArgumentOutOfRangeException(nameof(value), "Provided argument is out of range and was not discovered in the target array.");
        }

        static ref int Min(ref int x, ref int y)
        {
            // Limitation - "By-value returns may only be used in methods that return by value"
            // return x < y ? x : y;

            // Also neither of these are legal syntax either...
            // return x < y ? (ref x) : (ref y);
            // return ref (x < y ? x : y);

            // Only way, at this stage, it to write a full-fat if statement
            if (x < y)
            {
                return ref x;
            }

            return ref y;
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
