using System;
using TechRound_test_task.UserInterface;

namespace TechRound_test_task
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserInterface userInterface = new ConsoleInterfaceTask1();
            userInterface.Run();
        }
    }
}