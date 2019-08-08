using System;
using System.Linq;

namespace Penguin.Extensions.Randomizer
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class RandomExtensions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        #region Methods

        /// <summary>
        /// Creates a random bool
        /// </summary>
        /// <param name="random">The source randomizer</param>
        /// <returns>A random bool</returns>
        public static bool Bool(this Random random) => random.Next(0, 1) == 1;

        /// <summary>
        /// Creates a random DateTime
        /// </summary>
        /// <param name="random">The source randomizer</param>
        /// <param name="MinDate">The minimum acceptable date</param>
        /// <param name="MaxDate">The maximum acceptable date</param>
        /// <returns>A random date</returns>
        public static DateTime DateTime(this Random random, DateTime? MinDate = null, DateTime? MaxDate = null)
        {
            MinDate = MinDate ?? System.DateTime.MinValue;
            MaxDate = MaxDate ?? System.DateTime.Now;

            int range = (MaxDate - MinDate).Value.Days;
            return MinDate.Value.AddDays(random.Next(range));
        }

        /// <summary>
        /// Creates a random array of bytes of a given length
        /// </summary>
        /// <param name="random">The source randomizer</param>
        /// <param name="length">The length of the array</param>
        /// <returns>The random byte array</returns>
        public static byte[] RandomBytes(this System.Random random, int length)
        {
            byte[] randomBytes = new byte[length];
            random.NextBytes(randomBytes);
            return randomBytes;
        }

        /// <summary>
        /// Creates a random array of bytes of a given length
        /// </summary>
        /// <param name="random">The source randomizer</param>
        /// <param name="length">The length of the array</param>
        /// <returns>The random byte array</returns>
        public static byte[] RandomBytes(this System.Random random, long length)
        {
            byte[] randomBytes = new byte[length];
            random.NextBytes(randomBytes);
            return randomBytes;
        }

        /// <summary>
        /// Creates a random string from the source character set
        /// </summary>
        /// <param name="random">The source randomizer</param>
        /// <param name="length">The length of the random string</param>
        /// <param name="chars">The source pool of characters</param>
        /// <returns>The random string</returns>
        public static string String(this System.Random random, int length, string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
        {
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Gets a double between two values
        /// </summary>
        /// <param name="r">Source randomizer</param>
        /// <param name="Min">Min value</param>
        /// <param name="Max">Max value</param>
        /// <returns>A random double</returns>
        public static Double NextDouble(this System.Random r, double Min, double Max)
        {
            return r.NextDouble() * (Max - Min) + Min;
        }
        #endregion Methods
    }
}