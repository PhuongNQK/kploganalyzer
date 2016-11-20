using System;
using System.Text;

namespace Kp.Tools.LogAnalyzer.Common
{
    public static class ValueGenerator
    {
        private static Random s_Randomizer = new Random(); // Note that if the same Random instance is used by several concurrent thread, it can malfunction.

        public static bool RandomBoolean()
        {
            return (s_Randomizer.Next() % 2 == 0);
        }

        public static int RandomInt()
        {
            return (s_Randomizer.Next(int.MaxValue));
        }

        /// <summary>
        /// Returns a random value which is larger than or equal to <paramref name="minValue"/>
        /// and smaller than <paramref name="maxValue"/>.
        /// </summary>
        /// <param name="minValue">Must be smaller than or equal to <paramref name="maxValue"/></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int RandomInt(int minValue, int maxValue)
        {
            return (s_Randomizer.Next(minValue, maxValue));
        }

        public static char RandomChar()
        {
            return ((char)s_Randomizer.Next(char.MaxValue));
        }

        public static T RandomArrayItem<T>(T[] items)
        {
            if (items == null || items.Length == 0)
            {
                return default(T);
            }

            int index = s_Randomizer.Next(0, items.Length);
            return items[index];
        }

        public static string RandomString(int minLength = 0, int maxLength = 0)
        {
            if (minLength < 0) { minLength = 0; }
            if (maxLength <= minLength) { maxLength = minLength + 1; }

            int length = RandomInt(minLength, maxLength);
            if (length == 0) { return string.Empty; }

            var builder = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                builder.Append(RandomChar());
            }

            return builder.ToString();
        }
    }
}