using System;

namespace InputOutput
{
    public static class ConsoleInput
    {
        public static string GetLine()
        {
            return Console.ReadLine();
        }

        public static int GetIntValue()
        {
            try
            {
                return Convert.ToInt32(GetLine());
            }
            catch (Exception e)
            {
                ErrorWriter.PrintError(e);
                throw;
            }
        }

        public static ConsoleKeyInfo GetKey(bool intercept = true)
        {
            return Console.ReadKey(intercept);
        }
    }
}