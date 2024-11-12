namespace Grow.Extensions
{
    public static partial class BoolExt
    {
        /// <summary>  
        /// Converts the boolean value to an integer (1 for true, 0 for false).  
        /// </summary>  
        /// <param name="value">The boolean value to convert.</param>  
        /// <returns>1 if true, 0 if false</returns>  
        public static int ToInt(this bool value) => value ? 1 : 0;
    }
}