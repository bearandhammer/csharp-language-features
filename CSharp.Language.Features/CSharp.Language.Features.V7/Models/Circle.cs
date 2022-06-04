using System;

namespace CSharp.Language.Features.V7.Models
{
    /// <summary>
    /// Utility class that represents a circle.
    /// </summary>
    /// <seealso cref="Shape" />
    internal sealed class Circle : Shape
    {
        /// <summary>
        /// This circle says hello!
        /// </summary>
        internal void SayHello() => Console.WriteLine("Hello from this circle!");
    }
}
