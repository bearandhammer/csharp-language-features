using System;
using System.Collections.Generic;

namespace CSharp.Language.Features.V7.Models
{
    /// <summary>
    /// A class representing a person to show further usages of expression-bodies in C# 7.
    /// NOTE: language feature contributed by the community.
    /// </summary>
    internal sealed class Person
    {
        /// <summary>
        /// A test person id for demo purposes.
        /// </summary>
        private const int testId = 1;

        /// <summary>
        /// A static dictionary representing person names (illustration only).
        /// </summary>
        private static readonly Dictionary<int, string> names = new Dictionary<int, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// Constructors can be expressed with an expression body.
        /// </summary>
        /// <param name="id">The identifier of the person..</param>
        /// <param name="name">The name of the person.</param>
        internal Person(int id, string name) => names.Add(id, name);

        /// <summary>
        /// Finalizes an instance of the <see cref="Person"/> class.
        /// Can also be expressed with an expression body.
        /// </summary>
        ~Person() => Console.WriteLine("Person destructor called.");

        /// <summary>
        /// Gets or sets the person name (using testId). Illustrating expression-bodied properties.
        /// </summary>
        public string Name
        {
            get => names[testId];
            set => names[testId] = value;
        }

        /// <summary>
        /// Gets the testId (example of expression-bodied get only).
        /// </summary>
        public int TestId => testId;
    }
}
