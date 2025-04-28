using static Core.Types.Types;

namespace Core
{
    public static class Utils
    {
        public static string CheckValidData(string name)
        {
            ExceptionType exceptionType = 0;
            if (string.IsNullOrEmpty(name))
            {
                exceptionType = ExceptionType.NameFaild;
            }
            return exceptionType.ToString();
        }
    }
}
