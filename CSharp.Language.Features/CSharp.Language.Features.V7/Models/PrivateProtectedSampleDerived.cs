using System;

namespace CSharp.Language.Features.V7.Models
{
    /// <summary>
    /// Derived class to further illustrate access modifier functionality.
    /// </summary>
    /// <seealso cref="PrivateProtectedSampleBase" />
    public class PrivateProtectedSampleDerived : PrivateProtectedSampleBase
    {
        /// <summary>
        /// Public demo method to illustrate access to fields on the base class.
        /// </summary>
        public void IllustrateAccessToFields()
        {
            Console.WriteLine("PrivateProtectedSampleDerived: b is protected internal (can access). Setting to 3000.");
            b = 3000;
            Console.WriteLine($"b = {b}");

            Console.WriteLine("PrivateProtectedSampleDerived: c is private protected (can access). Setting to 4000.");
            c = 4000;
            Console.WriteLine($"c = {c}");
        }
    }
}
