using CSharp.Language.Features.V7.Constants;
using CSharp.Language.Features.V7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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

        /// <summary>
        /// Executes demo code showing usage of default expression changes in C# V7.1.
        /// </summary>
        internal void ExecuteDefaultExpressionChangesFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Default Expression Changes Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            // Literal - keyword which represents a particular value. Default literals

            // Older mechanic - use of the default keyword specifying the type (ValueTypes, 0 or false for example or null for reference types)
            int sampleNumber = default(int);
            Person samplePerson = default(Person);

            Console.WriteLine($"sampleNumber = {sampleNumber}");
            Console.WriteLine($"samplePerson {(samplePerson != null ? "is not null" : "is null")}");

            // Simplify default expression (default literal) - inferred by compiler from the context
            int sampleNumberTwo = default;

            // Can be used with constants (0 forever in this case)
            const int sampleConstantNumber = default;

            // Nullable const is a no go, as you would expect
            //const int? nullableSampleConstantNumber = default;

            // Normal nullable, fine - default null
            int? nullableSampleNumber = default;

            Console.WriteLine($"sampleNumberTwo = {sampleNumberTwo}");
            Console.WriteLine($"sampleConstantNumber = {sampleConstantNumber}");
            Console.WriteLine($"nullableSampleNumber {(nullableSampleNumber.HasValue ? "is not null" : "is null")}");

            // This sample array is valid as we have at least one value to key off...we know we are dealing with int[]
            var sampleArray = new[] { default, 66, default };

            // This, however is invalid of course (why type is the array? We don't know)
            //var invalidSampleArray = new[] { default, default, default };

            // Default can be used if equality statements, like this...
            string sampleString = default;
            if (sampleString == default)
            {
                Console.WriteLine("sampleString is equal to its 'default' value.");
            }

            // Ternary example, here sampleNumberThree has an inferred type of double (0.0 being the default)
            var sampleNumberThree = sampleNumber > 0 ? default : 1.5;
            Console.WriteLine($"sampleNumberThree = {sampleNumberThree}");

            // Show the use of a default value in a method signature/as a return value
            Console.WriteLine($"GetTimeStamps = {GetTimeStamps()}");
        }

        /// <summary>
        /// Executes demo code showing inferred tuple name support in C# V7.1.
        /// </summary>
        internal void ExecuteInferredTupleNamesFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Inferred Tuple Names Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            // Original sample tuple
            var sampleOne = (name: "Lewis", age: 38);
            Console.WriteLine($"sampleOne = {sampleOne}");

            // Another sample, based on sampleOne
            var sampleTwo = (sampleOne.name, sampleOne.age);

            // You would have previously been forced to reference tuple facets as sampletwo.Item1, etc. But now...
            Console.WriteLine($"sampleTwo age = {sampleTwo.age}");

            // More complex example. Here we use linq to generate tuples but not that the name 'Length' has been inferred for us here
            var sampleThree = new[] { "Jill", "Bob", "Harry", "Jane" };
            var sampleThreeResult = sampleThree
                .Select(person => (
                    person.Length,
                    FirstChar: person[0]
                ))
                .Where(personFacets => personFacets.Length == 4);

            Console.WriteLine($"sampleThreeResult = {string.Join(",", sampleThreeResult)}");

            // This also works through deconstruction
            var sampleFour = DateTime.UtcNow;
            var sampleFourResult = (sampleFour.Hour, sampleFour.Minute);
            Console.WriteLine($"sampleFourResult Hour = {sampleFourResult.Hour}");

            // This works even through this kind of assignment
            var sampleFiveResult = ((sampleFourResult.Hour, sampleFourResult.Minute) = (14, 15));
            Console.WriteLine($"sampleFourResult Hour = {sampleFiveResult.Hour}, Minute = {sampleFiveResult.Minute}");
        }

        /// <summary>
        /// Executes demo code showing inferred tuple name support in C# V7.1.
        /// </summary>
        internal void ExecutePatternMatchingWithGenericsFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Pattern Matching with Generics Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            // Create a sample type to illustrate the changes to pattern matching (invoking Cook)
            Cauliflower sampleVegetable = new Cauliflower();
            Cook(sampleVegetable);
        }

        /// <summary>
        /// Executes demo code showing usage of an overaching async Main method in C# V7.1.
        /// </summary>
        internal async Task ExecuteUtiliseAsyncMainFeatureSnippet()
        {
            Console.WriteLine($"{Environment.NewLine}Utilise Async Main Feature Snippet {Environment.NewLine}{TextConstant.Separator}");

            // Demo only - retrieve robots.txt content from google using an async API
            using (HttpClient client = new HttpClient())
            {
                string robotsTxtContent = await client.GetStringAsync("https://google.com/robots.txt");

                if (!string.IsNullOrWhiteSpace(robotsTxtContent))
                {
                    string topFiveRobotsTxtLines = string.Join(",", robotsTxtContent.Split("\n").ToList().GetRange(0, 5));
                    Console.WriteLine($"topFiveRobotsTxtLines = {topFiveRobotsTxtLines}");
                }
            }
        }

        /// <summary>
        /// Example demo method that illustrates the changes to pattern matching in C# 7.1.
        /// </summary>
        /// <typeparam name="T">A type inheriting from <see cref="Vegetable"/>.</typeparam>
        /// <param name="vegetable">The vegetable to cook.</param>
        private static void Cook<T>(T vegetable)
            where T : Vegetable
        {
            // Before the changes, the following would have been necessary to compile code (using pattern matching, noting the cast to object)
            //if ((object)vegetable is Cauliflower cauliflowerOne)
            //{
            //    Console.WriteLine($"vegetable is a cauliflower (if check). Type = {cauliflowerOne.GetType().Name }");
            //}

            //switch ((object)vegetable)
            //{
            //    case Cauliflower cauliflowerTwo:
            //        Console.WriteLine($"vegetable is a cauliflower (switch check). Type = {cauliflowerTwo.GetType().Name}");
            //        break;
            //    default:
            //        break;
            //}

            // However, now the casting is no longer required as of this version
            if (vegetable is Cauliflower cauliflowerOne)
            {
                Console.WriteLine($"vegetable is a cauliflower (if check). Type = {cauliflowerOne.GetType().Name}");
            }

            switch (vegetable)
            {
                case Cauliflower cauliflowerTwo:
                    Console.WriteLine($"vegetable is a cauliflower (switch check). Type = {cauliflowerTwo.GetType().Name}");
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Example demo method that illustrates the use of default in signatures and as a return value.
        /// </summary>
        /// <param name="items">The sample items (not used in this sample)..</param>
        /// <returns>A default DateTime (as an example only).</returns>
        private static DateTime GetTimeStamps(List<int> items = default) => default;
    }
}
