namespace CSharp.Language.Features.V7.Models
{
    /// <summary>
    /// Utility class that represents a point.
    /// </summary>
    internal sealed class Point
    {
        /// <summary>
        /// Gets or sets the x value of the point.
        /// </summary>
        internal int X { get; set; }

        /// <summary>
        /// Gets or sets the y value of the point.
        /// </summary>
        internal int Y { get; set; }

        /// <summary>
        /// Deconstructs the <see cref="X"/> and <see cref="Y"/> properties stored on this type
        /// (providing them as two integers to the caller).
        /// </summary>
        /// <param name="x">The x value to return to the caller.</param>
        /// <param name="y">The y value to return to the caller.</param>
        internal void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }
}
