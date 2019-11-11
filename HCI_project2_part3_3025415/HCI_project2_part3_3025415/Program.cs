/* Nathan Wemmer
 * nww8@zips.uakron.edu
 * Project 2 Part 3
 * Instructions: When pressing 's' to interupt, you have to press 'enter' after because the program
 * uses ReadLine() method to check when there is a key available. If the key available is not 's', 
 * then ignore the input. THIS HAS BEEN FIXED, NO LONGER LIKE THIS 
 * Everything in this one works as it should. 
 */


using System;
using System.Threading; //for multithreading

namespace PA2_part3
{
    class Program
    {
        //pi calculation variables
        const double pi = Math.PI;
        static double piCalc = Math.Sqrt(pi);
        //bools for the loops
        private static bool done = false;
        private static bool stopped = false;

        static void Main(string[] args)
        {
            //user inputted string
            string userInput = "";
            done = false;
            //while its not done run the loop
            while (!done)
            {
                stopped = false;
                //actually get the user input
                Console.WriteLine("Please enter an integer or'q' to quit.");
                userInput = Console.ReadLine();
                
                int data;
                //if it is a valid number that can be parsed, then go on with the loop
                if (int.TryParse(userInput, out data))
                {
                    if (data > 0)
                    {
                        //if number inputted is greater than 0, output it and start the threads
                        Console.WriteLine("You have asked to calculate the square root of pi " + " times .");
                        Thread calc = new Thread(() => calculation(data));
                        Thread interrupt = new Thread(interruption);
                        calc.Start();
                        interrupt.Start();
                        //join the threads
                        calc.Join();
                        interrupt.Join();
                        
                        done = false;

                    }
                    else
                    {
                        //wrong number entered
                        Console.WriteLine("Enter a valid number please.");
                    }
                }
                //user inputs a 'q', exits program
                else if (userInput.ToLower() == "q")
                {
                    break;
                }

            }
        }
        //this is the interrupton function that detects a keypress and verifies it was the 's' key to stop
        static void interruption()
        {
            while (!done)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.S)
                {
                    stopped = true;
                }
            }
        }
        //calculation function thread that outputs the actual information, and the square root of pi
        static void calculation(int numberOfTimes)
        {
            double end = 0;
            stopped = false;
            done = false;

            for (var i = 1; i <= numberOfTimes; ++i)
            {
                if (stopped)
                {
                    break;
                }
                Console.WriteLine(i);
                end = Math.Sqrt(piCalc);
            }
            done = true;
            Console.WriteLine("The square root of PI is " + piCalc + ". ");
        }

        /*
        public static void setData(string userInput)
        {

            while (!userInput.ToLower().Equals("q"))
            {

                //if (!userInput.ToLower().Equals("q"))
                // {
                double pi = Math.PI;
                double piCalc = pi;
                int numberOfTimes = int.Parse(userInput);
                bool completed = false;

                Console.WriteLine("You have asked to calculate the square root " + userInput + " times.");
                for (int x = 1; x <= numberOfTimes && (completed != true); x++)
                {
                    Console.WriteLine(x);
                    piCalc = Math.Sqrt(pi);
                }

                // }
            }
        }
        */
    }
}

/* class threadData
 {

     public static void setData(string userInput)
     {

         while (!userInput.ToLower().Equals("q"))
         {

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
                 }

             }
         }
     }
 }
*/

