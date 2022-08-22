namespace DoIt.Client.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string str)
        {

            if (str.Length == 1)
                return char.ToUpper(str[0]).ToString();
            else
                return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}
