namespace CSharp.Language.Features.V7.Models
{
    /// <summary>
    /// A sample point type (as a struct) for demo purposes.
    /// Struct size - 8 bytes per double.
    /// </summary>
    public struct PointStruct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PointStruct"/> struct.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        public PointStruct(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets or sets the X value.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the Y value.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Resets the X and the Y values on this struct to 0.
        /// </summary>
        public void Reset() => X = Y = 0;

        /// <summary>
        /// Converts this instance to a <see cref="string"/>.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this struct.</returns>
        public override string ToString() => $"({X},{Y})";
    }
}
