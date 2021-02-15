using System;

namespace GuessRandomNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomNumber = new Random();

            int correctNumber = randomNumber.Next(1, 10);
            string val;
            int userGuess = 0;
            Console.WriteLine("I am thinking of a random number between 1 and 10, inclusive... Can you guess it?");
            do
            {
                val = Console.ReadLine();
                userGuess = Convert.ToInt32(val);
                if(userGuess > correctNumber)
                {
                    Console.WriteLine("Your guess is too high! Try again");
                }
                else if(userGuess < correctNumber)
                {
                    Console.WriteLine("Your guess is too low! Try again");
                }

            } while (!userGuess.Equals(correctNumber));

            Console.WriteLine($"You have successfully guessed the number! It is {correctNumber}");
        }
    }
}
