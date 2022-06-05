using System;

namespace CSharp.Language.Features.V7.UtilityDemo
{
    /// <summary>
    /// Represents a utility class to illustrate the syntax changes around local functions.
    /// Equation: b*b-4*a*c (sticking with a, b, c for easy illustration)
    /// </summary>
    internal sealed class EquationSolver
    {
        /// <summary>
        /// Illustrates the classic use of a local function to solve an equation (illustration only).
        /// </summary>
        /// <param name="a">The equation value 'a'.</param>
        /// <param name="b">The equation value 'b'.</param>
        /// <param name="c">The equation value 'c'.</param>
        /// <returns>A <see cref="Tuple"/> representing the resolution.</returns>
        internal Tuple<double, double> SolveQuadraticClassicLocalFunctionSyntax(double a, double b, double c)
        {
            // Classic way to express an inline local function (we must provide unique argument names in the signature)
            var CalculateDiscriminant = new Func<double, double, double, double>(
                (aa, bb, cc) => bb * bb - 4 * aa * cc);

            double disc = CalculateDiscriminant(a, b, c);

            return GetQuadraticResolutionTuple(a, b, disc);
        }

        /// <summary>
        /// Illustrates the new syntax of a local function (v1) to solve an equation (illustration only).
        /// </summary>
        /// <param name="a">The equation value 'a'.</param>
        /// <param name="b">The equation value 'b'.</param>
        /// <param name="c">The equation value 'c'.</param>
        /// <returns>A <see cref="Tuple"/> representing the resolution.</returns>
        internal Tuple<double, double> SolveQuadraticNewLocalFunctionSyntaxOne(double a, double b, double c)
        {
            // Define a local function, with unique argument names (signature) - can be expression-bodied of course
            double CalculateDiscriminant(double aa, double bb, double cc)
            {
                return bb * bb - 4 * aa * cc;
            }

            double disc = CalculateDiscriminant(a, b, c);

            return GetQuadraticResolutionTuple(a, b, disc);
        }

        /// <summary>
        /// Illustrates the new syntax of a local function (v3) to solve an equation (illustration only).
        /// </summary>
        /// <param name="a">The equation value 'a'.</param>
        /// <param name="b">The equation value 'b'.</param>
        /// <param name="c">The equation value 'c'.</param>
        /// <returns>A <see cref="Tuple"/> representing the resolution.</returns>
        internal Tuple<double, double> SolveQuadraticNewLocalFunctionSyntaxThree(double a, double b, double c)
        {
            // Then, when using the function, we don't provide parameters (as the local function has used the raw arguments)
            double disc = CalculateDiscriminant();

            return GetQuadraticResolutionTuple(a, b, disc);

            // Scope rules for local functions - same as if we were in a class, so they can reside 'after' their usage (completely valid)
            double CalculateDiscriminant() => b * b - 4 * a * c;
        }

        /// <summary>
        /// Illustrates the new syntax of a local function (v2) to solve an equation (illustration only).
        /// </summary>
        /// <param name="a">The equation value 'a'.</param>
        /// <param name="b">The equation value 'b'.</param>
        /// <param name="c">The equation value 'c'.</param>
        /// <returns>A <see cref="Tuple"/> representing the resolution.</returns>
        internal Tuple<double, double> SolveQuadraticNewLocalFunctionSyntaxTwo(double a, double b, double c)
        {
            // Define a local function with no arguments using the chained in arguments to the method directly (refactored to expression-bodied this this time)
            double CalculateDiscriminant() => b * b - 4 * a * c;

            // Then, when using the function, we don't provide parameters (as the local function has used the raw arguments)
            double disc = CalculateDiscriminant();

            return GetQuadraticResolutionTuple(a, b, disc);
        }

        /// <summary>
        /// Gets a <see cref="Tuple"/> representing the result for all of the demo methods in this type.
        /// </summary>
        /// <param name="a">The equation value 'a'.</param>
        /// <param name="b">The equation value 'b'.</param>
        /// <param name="disc">The discrimnator value.</param>
        /// <returns>A <see cref="Tuple"/> illustrating the result.</returns>
        private static Tuple<double, double> GetQuadraticResolutionTuple(double a, double b, double disc)
        {
            double rootDisc = Math.Sqrt(disc);

            return Tuple.Create(
                (-b - rootDisc) / (2 * a),
                (-b + rootDisc) / (2 * a));
        }
    }
}
