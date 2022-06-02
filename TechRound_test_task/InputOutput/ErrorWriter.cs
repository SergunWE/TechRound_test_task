using System;

namespace InputOutput
{
    public static class ErrorWriter
    {
        public static void PrintError(Exception e, bool needClear = true)
        {
            if (needClear) Console.Clear();
            Console.WriteLine($"{e.Message}");
        }
    }
}