using CSharp.Language.Features.V7.Models;
using System;

namespace CSharp.Language.Features.PrivateProtected.Models
{
    /// <summary>
    /// Further derived class to further illustrate access modifier functionality.
    /// </summary>
    /// <seealso cref="PrivateProtectedSampleBase" />
    public class FurtherPrivateProtectedSampleDerived : PrivateProtectedSampleBase
    {
        /// <summary>
        /// Public demo method to illustrate access to fields on the base class from another derived class (different assembly).
        /// </summary>
        public void FurtherIllustrateAccessToFields()
        {
            Console.WriteLine("FurtherPrivateProtectedSampleDerived: b is protected internal (can access). Setting to 3001.");
            b = 30001;
            Console.WriteLine($"b = {b}");

            // c is innaccessible from this assembly
            Console.WriteLine("FurtherPrivateProtectedSampleDerived: c is private protected (cannot access).");
            //c = 4000;
            //Console.WriteLine($"c = {c}");
        }
    }
}
