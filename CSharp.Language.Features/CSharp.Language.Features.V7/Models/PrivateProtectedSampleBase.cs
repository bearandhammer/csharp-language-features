using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Language.Features.V7.Models
{
    /// <summary>
    /// Test class for illustrating the 'private protected' access modifier. Uses fields for demo purposes.
    /// </summary>
    public class PrivateProtectedSampleBase
    {
        /// <summary>
        /// Represents a value available within this type only.
        /// </summary>
        private int a;

        /// <summary>
        /// Represents a value available in derived classes (in any assembly) and from types in this assembly.
        /// </summary>
        protected internal int b;

        /// <summary>
        /// Represents a value available within this type and derived classes (in this assembly only).
        /// </summary>
        private protected int c;
    }
}
