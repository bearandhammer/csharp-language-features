using System;

namespace CSharp.Language.Features.V7.Models
{
    /// <summary>
    /// Utility class that represents a contact.
    /// </summary>
    internal sealed class Contact
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="name">The name of the contact.</param>
        /// <exception cref="ArgumentNullException">name - A contact must have a non-null name.</exception>
        internal Contact(string name)
        {
            // Use throw expressions in the constructor (as part of null coalesce or ternary operator statements)
            Name = name ?? throw new ArgumentNullException(nameof(name), "A contact must have a non-null name.");
        }

        /// <summary>
        /// Gets the name of the contact.
        /// </summary>
        internal string Name { get; }

        /// <summary>
        /// Calculates the bonus for a contract (just a utility method to show exceptions thrown value a ternary operator).
        /// </summary>
        /// <param name="bonusBasePercentage">The bonus base percentage to give the contact.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Bonus percentage must be greater than zero. - bonusBasePercentage</exception>
        internal int CalculateBonus(int bonusBasePercentage) =>
            bonusBasePercentage > 0 ? bonusBasePercentage + 1 : throw new ArgumentException("Bonus percentage must be greater than zero.", nameof(bonusBasePercentage));
    }
}
