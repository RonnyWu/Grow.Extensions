using System.Runtime.CompilerServices;

namespace Grow.Extensions
{
    public static class BoolTo
    {
        /// <summary>
        /// Converts the boolean value to an integer (1 for true, 0 for false).
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <returns>1 if true, 0 if false</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this bool value) => value ? 1 : 0;
    }
}