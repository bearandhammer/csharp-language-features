using System;

namespace CSharp.Language.Features.RefAssemblies
{
    /*
        Ref assemblies:

        Allows assemblies to be produced that provides information to the surface, public API (for extension, for example) without leaking implementation (or having
        to distribute a large assembly)

        Docs: https://docs.microsoft.com/en-us/dotnet/standard/assembly/reference-assemblies
        Docs detailing refout/refonly (refonly = reference assembly only): https://github.com/dotnet/roslyn/blob/main/docs/features/refout.md

        Example...
        1. csc Program.cs /refout:sample.dll
        2. dir = you'll see sample.dll has been omitted.
        3. explorer . = open and decompile - private fields and public API implementations are omitted (throw null) - can still extend/work against this binary however
        4. Constructors are automatically added if not in place
    */

    /// <summary>
    /// A sample type to test emitted code (reference assemblies).
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// The identifier of the contact.
        /// </summary>
        private readonly int id;

        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        protected string Name { get; set; }

        /// <summary>
        /// Triggers the greeting of this contact.
        /// </summary>
        public void Greeting() => Console.WriteLine($"Hi, my name is {Name}");
    }

    /// <summary>
    /// <see cref="Program"/> class for testing out reference assemblies.
    /// </summary>>
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        private static void Main()
        {
        }
    }
}
