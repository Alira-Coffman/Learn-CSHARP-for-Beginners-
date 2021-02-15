using System;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {

            // DECLARING INT VARIABLES

            int firstNumber = 2;
            int secondNumber = 5;

            Console.WriteLine($"The first number is: {firstNumber}. The second number is: {secondNumber}" );

            // not Explicit Type - Good for if you do not know the type
            var subtraction = 7;


            int answer;
            string prompt = ". Press any key when ready";


            //Console.WriteLine($"Think of a number between 1 and 10 {prompt}");
            //Console.ReadKey();
            //Console.WriteLine($"Multiply your number by {firstNumber} {prompt}");
            //Console.ReadKey();
            //Console.WriteLine($"Now multiply the result by {secondNumber} {prompt}");
            //Console.ReadKey();
            //Console.WriteLine($"Divide the result by the number you originally though of {prompt}");
            //Console.ReadKey();
            //Console.WriteLine($"Now subtract {subtraction} {prompt}");
            //Console.ReadKey();
            //answer = firstNumber * secondNumber - subtraction;

            //Console.WriteLine($"The answer is {answer}");

            //BUILT IN TYPES

            Console.WriteLine($"byte: minimum {byte.MinValue} and maximum {byte.MaxValue}");
        }
    }
}
