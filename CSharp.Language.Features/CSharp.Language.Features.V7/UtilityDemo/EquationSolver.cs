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
        internal static Tuple<double, double> SolveQuadraticClassicLocalFunctionSyntax(double a, double b, double c)
        {
            // Classic way to express an inline local function (we must provide unique argument names in the signature)
            var CalculateDiscriminant = new Func<double, double, double, double>(
                (aa, bb, cc) => bb * bb - 4 * aa * cc);

            double disc = CalculateDiscriminant(a, b, c);
            double rootDisc = Math.Sqrt(disc);

            return Tuple.Create<double, double>(
                (-b - rootDisc) / (2 * a),
                (-b + rootDisc) / (2 * a));
        }

        ///// <summary>
        ///// Illustrates the new syntax of a local function (v1) to solve an equation (illustration only).
        ///// </summary>
        ///// <param name="a">The equation value 'a'.</param>
        ///// <param name="b">The equation value 'b'.</param>
        ///// <param name="c">The equation value 'c'.</param>
        ///// <returns>A <see cref="Tuple"/> representing the resolution.</returns>
        //internal static Tuple<double, double> SolveQuadraticNewLocalFunctionSyntaxOne(double a, double b, double c)
        //{
        //    // Define a local function, with unique argument names (signature)
        //    double CalculateDiscriminant
        //}
    }
}
