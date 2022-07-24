namespace DoIt.Api.Extensions
{
    public static class StringExtensions
    {
        public static string ToControllerName(this string controllerName)
        {
            return controllerName.Replace("Controller", "");
        }
    }
}
