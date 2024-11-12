namespace Grow.Extensions
{
    public static class CharSyntax
    {
        /// <summary>  
        /// Determines whether the char is a digit (0-9).  
        /// </summary>  
        public static bool IsDigit(this char value) => char.IsDigit(value);  

        /// <summary>  
        /// Determines whether the char is a letter.  
        /// </summary>  
        public static bool IsLetter(this char value) => char.IsLetter(value); 
    }
}