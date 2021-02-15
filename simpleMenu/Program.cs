using System;

namespace simpleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            float totalFunds = 16.87f;
            string[] coffee = { "Cappucino", "Latte", "Americano", "Mocha", "Macchiato", "Expresso", "Quit" };
            float[] price = { 3.45f, 4.25f, 1.2f, 4.60f, 6.70f, 8.99f };
            while(totalFunds > 1.2f)
            {
                Console.WriteLine($"Your total avaible funds are {totalFunds}");
                Console.WriteLine("Please choose one of the following options: ");
                for (int i = 0; i < coffee.Length; i++)
                {
                    if (i != coffee.Length - 1)
                    {
                        Console.WriteLine($"{i + 1} - {coffee[i],-10} {price[i],10:C}");
                    }
                    else
                    {
                        Console.WriteLine("Q - " + coffee[i]);
                    }
                }
            

                char userChoice = Console.ReadKey(true).KeyChar;
                int selection;
               
                if (!userChoice.Equals('Q') && !userChoice.Equals('q'))
                {
                    selection = userChoice - '0';
                    Console.WriteLine("You chose " + coffee[selection - 1]);
                    

                }
                else
                {
                    Console.WriteLine("Sorry we could not assist you today. GoodBye");
                    return;
                }
                if (totalFunds - price[selection - 1] > 0)
                {
                    totalFunds -= price[selection - 1];
                
                    switch (selection - 1)
                    {
                        case 0:
                            Console.WriteLine("Steaming Milk.......");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine("Mixing milk.........");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine("Making Coffee........");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine("Mixing Coffee & Milk..");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        case 1:
                            Console.WriteLine("Brewing Coffee.......");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine("Whisking Milk.......");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine("Foam Rising.......");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine("Mixing Coffee & Milk.......");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        case 2:
                            Console.WriteLine("Adding espresso shot.......");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine("Adding hot water.......");
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine("Mixing.......");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        case 3:
                            Console.WriteLine("Making Coffee.......");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        case 4:
                            Console.WriteLine("Making Coffee.......");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        case 5:
                            Console.WriteLine("Making Coffee.......");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("You do not have enough funds for your beverage choice");
                }
                Console.WriteLine("Your drink is finished! Enjoy");
            }

            Console.WriteLine("You do not have enough funds.");

        }
    }
}
