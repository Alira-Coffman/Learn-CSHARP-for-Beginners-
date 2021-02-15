using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            
            RPS game1 = new RPS();
            while(true)
            {
                game1.GenerateComputerMove();
                game1.UserMoveSelection();
                game1.Winner();
            }
          

        }
    }

    class RPS
    {
       int computerMove;
        int userMove;
        string[] moves = { "Rock", "Paper", "Scissors" };

        public RPS()
        {
            computerMove = 0;
            userMove = 0;
        }
        public void GenerateComputerMove()
        {
            Random rand = new Random();
            int moveTemp = rand.Next(0, 2);
            computerMove =moveTemp;
        }
         public void UserMoveSelection()
        {
            char userChoice;
           
                Console.WriteLine("R - Rock");
                Console.WriteLine("P - Paper");
                Console.WriteLine("S - Scissors");
                Console.WriteLine("Please make a selection");
                userChoice = Console.ReadKey(true).KeyChar;
                Console.WriteLine($"{userChoice}");
           // } while (!userChoice.Equals('R') || !userChoice.Equals('P') || !userChoice.Equals('S') || !userChoice.Equals('r') || !userChoice.Equals('p') || !userChoice.Equals('s'));

            switch(userChoice)
            {
                case 'R':
                case 'r':
                    userMove = 0;
                    break;
                case 'P':
                case 'p':
                    userMove = 1;
                    break;
                case 'S':
                case 's':
                    userMove = 2;
                    break;
            }
            
           
        }
        public void Winner()
        {
            Console.WriteLine($"Your move: {moves[userMove]}");
            Console.WriteLine($"Computer move: {moves[computerMove]}");
            if ( userMove == 0 && computerMove == 2 || userMove == 1 && computerMove == 2 || userMove == 1 && computerMove == 0 || userMove == 2 && computerMove ==1)
            {

                Console.WriteLine("You win!");
            }
            else if(userMove == computerMove)
            {
                Console.WriteLine("It is a tie");
            }
            else
            {
                Console.WriteLine("You lost...");
            }

        }
    }
}
