namespace CSharp.Language.Features.V7.Models
{
    /// <summary>
    /// Utility class that represents a rectangle.
    /// </summary>
    /// <seealso cref="Shape" />
    internal sealed class Rectangle : Shape
    {
        /// <summary>
        /// Gets or sets the Height of this Rectangle.
        internal int Height { get; set; }

        /// <summary>
        /// Gets or sets the Width of this Rectangle.
        /// </summary>
        internal int Width { get; set; }
    }
}
