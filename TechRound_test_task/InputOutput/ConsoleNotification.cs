using System;

namespace InputOutput
{
    /// <summary>
    /// Вместо использования событий или паттерна наблюдатель
    /// </summary>
    public static class ConsoleNotification
    {
        public static void PrintNotice(string notice)
        {
            Console.WriteLine(notice);
        }
    }
}