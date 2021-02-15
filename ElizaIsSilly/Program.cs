using System;

namespace ElizaIsSilly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Doctor.Intro());
            string userInput = "";
            do
            {
                userInput = Console.ReadLine();
                Console.WriteLine(Doctor.response(userInput));
            } while (!userInput.Equals("quit", StringComparison.OrdinalIgnoreCase));


        }
    }
}
