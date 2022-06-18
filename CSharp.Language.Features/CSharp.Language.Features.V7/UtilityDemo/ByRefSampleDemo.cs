using System;

namespace CSharp.Language.Features.V7.UtilityDemo
{
    /// <summary>
    /// Static utility class that contains some sample methods for illustrating some usages of the ref keyword in C# 7.
    /// </summary>
    internal static class ByRefSampleDemo
    {
        /// <summary>
        /// Internal static demo method showing how to use ref in relation to method returns. Returns a reference to the value
        /// found in the array (by the supplied array and value to search for).
        /// </summary>
        /// <param name="numbers">The number array to search through.</param>
        /// <param name="value">The value to use in the search (to pull out a reference by).</param>
        /// <returns>A reference to the value discovered.</returns>
        /// <exception cref="ArgumentOutOfRangeException">value - Provided argument is out of range and was not discovered in the target array.</exception>
        internal static ref int GetIntRefFromArray(int[] numbers, int value)
        {
            for (int index = 0; index < numbers.Length; index++)
            {
                if (numbers[index] == value)
                {
                    // Using a reference in the return statement...
                    return ref numbers[index];
                }
            }

            // What do you return in this case...you would normally return -1 or 0, for example, but we need a 'ref'...
            // return -1; //Won't work

            // Also, you can't trick the compiler
            //int fail = -1;
            //return ref fail;

            // Throwing an exception is a way forward, however
            throw new ArgumentOutOfRangeException(nameof(value), "Provided argument is out of range and was not discovered in the target array.");
        }

        /// <summary>
        /// Internal static demo method showing some of the limitations around utilising ref returns (returns a reference to the minimum integer based on the supplied values).
        /// </summary>
        /// <param name="valueOne">The first number to assess.</param>
        /// <param name="valueTwo">The second number to assess.</param>
        /// <returns>A reference to the minimum value supplied.</returns>
        internal static ref int GetMinIntRef(ref int valueOne, ref int valueTwo)
        {
            // Limitation - "By-value returns may only be used in methods that return by value"
            // return valueOne < valueTwo ? valueOne : valueTwo;

            // Also neither of these are legal syntax either...
            // return valueOne < valueTwo ? (ref valueOne) : (ref valueTwo);
            // return ref (valueOne < valueTwo ? valueOne : valueTwo);

            // Only way, at this stage, it to write a full-fat if statement
            if (valueOne < valueTwo)
            {
                return ref valueOne;
            }

            return ref valueTwo;
        }
    }
}
