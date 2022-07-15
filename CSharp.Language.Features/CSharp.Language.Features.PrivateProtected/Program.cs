using CSharp.Language.Features.PrivateProtected.Models;
using CSharp.Language.Features.V7.Models;

namespace CSharp.Language.Features.PrivateProtected
{
    /// <summary>
    /// <see cref="Program"/> class for demonstrate facets of the private protected access modifier.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        private static void Main()
        {
            // Illustrate that access to the private protected member 'c' is no longer allowed (we are using a derived class but from a different assembly from its definition)
            PrivateProtectedSampleDerived sampleDerived = new PrivateProtectedSampleDerived();

            //int derivedAValue = sampleDerived.a;  // Innaccessible: we are not in the defining type
            //int derivedBValue = sampleDerived.b;  // Innaccessible: defined as 'internal', so only available inside the defining assembly
            //int derivedCValue = sampleDerived.c;  // Innaccessible: we are not in the defining type or a derived class (from the defining assembly)
            
            // All good (hit b and c)...
            sampleDerived.IllustrateAccessToFields();

            // Same again...
            FurtherPrivateProtectedSampleDerived furtherSampleDerived = new FurtherPrivateProtectedSampleDerived();

            //int furtherDerivedAValue = furtherSampleDerived.a;  // Innaccessible: we are not in the defining type
            //int furtherDerivedBValue = furtherSampleDerived.b;  // Innaccessible: defined as 'internal', so only available inside the defining assembly
            //int furtherDerivedCValue = furtherSampleDerived.c;  // Innaccessible: we are not in the defining type or a derived class (from the defining assembly)

            // All good - but can only access b
            furtherSampleDerived.FurtherIllustrateAccessToFields();
        }
    }
}