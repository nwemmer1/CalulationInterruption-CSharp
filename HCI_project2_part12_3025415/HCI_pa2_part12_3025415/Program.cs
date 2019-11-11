/* Nathan Wemmer
 * Project 2 Part 3
 * Instructions: When pressing 's' to interupt, you have to press 'enter' after because the program
 * uses ReadLine() method to check when there is a key available. If the key available is not 's', 
 * then ignore the input.
 */

using System;

namespace PA2_part12
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            while (!userInput.ToLower().Equals("q"))
            {
                Console.WriteLine("Please enter an integer or'q' to quit.");
                userInput = Console.ReadLine();
                if (!userInput.ToLower().Equals("q"))
                {
                    double pi = Math.PI;
                    double piCalc = pi;
                    int numberOfTimes = int.Parse(userInput);
                    bool completed = false;

                    Console.WriteLine("You have asked to calculate the square root " + userInput + " times.");
                    for (int x = 1; x <= numberOfTimes && (completed != true); x++)
                    {
                        Console.WriteLine(x);
                        piCalc = Math.Sqrt(pi);
                        if (Console.KeyAvailable)
                        {
                            completed = Console.ReadLine().ToLower().Equals("s");
                        }
                    }
                    if (completed != true)
                    {
                        Console.WriteLine("The square root of PI is " + Math.Round(piCalc, 3));
                    }
                }
            }

        }

    }
}
