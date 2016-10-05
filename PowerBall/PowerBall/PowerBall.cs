using System;
using System.Linq;
using System.Timers;
using System.Threading;

public class PowerBall
{
    public static void Main(string[] args)
    {
        // declare variables
        Random randNumber = new Random();
        int[] quickPick = new int[5];
        int num1;
        int num2;
        int num3;
        int num4;
        int num5;
        int pBall;
        string input;
        int numTicks;
        DateTime yr = System.DateTime.Now;

        // Greet user
        Console.WriteLine("Welcome to the PowerBall number generator " + yr.Month + "/" + yr.Day + "/" + yr.Year + "!");
        // loop as many times as user wants to play
        do
        {
            // prompt user for number of tickets
            Console.Write("How many tickets do you need numbers for?: ");
            input = Console.ReadLine();
            numTicks = (Convert.ToInt32(input));

            // validate input
            if (input.Length == 0 || numTicks < 1 || numTicks > 5 || numTicks == 0)
            {
                do
                {
                    Console.WriteLine("Input invalid.");
                    Console.Write("Try again by entering an integer (between 1 & 5): ");
                    input = Console.ReadLine();
                    numTicks = (Convert.ToInt32(input));
                } while ((input.Length == 0 || numTicks < 1 || numTicks > 5 || numTicks == 0));
            }

            // loop to select unique values for each number picked for each ticket
            for (int ticks = 1; ticks <= numTicks; ticks++)
            {
                num1 = randNumber.Next(1, 70);
                quickPick[0] = num1;
                num2 = randNumber.Next(1, 70);
                num3 = randNumber.Next(1, 70);
                num4 = randNumber.Next(1, 70);
                num5 = randNumber.Next(1, 70);
                pBall = randNumber.Next(1, 27);

                // randomly select unique values
                while (num2 == num1 || num2 == num3 || num2 == num4 || num2 == num5)
                {
                    num2 = randNumber.Next(1, 70);
                }

                quickPick[1] = num2;

                while (num3 == num1 || num3 == num2 || num3 == num4 || num3 == num5)
                {
                    num3 = randNumber.Next(1, 70);
                }

                quickPick[2] = num3;

                while (num4 == num1 || num4 == num2 || num4 == num3 || num4 == num5)
                {
                    num4 = randNumber.Next(1, 70);
                }

                quickPick[3] = num4;

                while (num5 == num1 || num5 == num2 || num5 == num3 || num5 == num4)
                {
                    num5 = randNumber.Next(1, 70);
                }

                quickPick[4] = num5;

                // organize numbers from lowest to highest using linq
                var inOrder =
                    from x in quickPick
                    orderby x
                    select x;

                // write each group of numbers to the console
                foreach (var element in inOrder)
                {
                    Console.Write("{0:D2} ", element);
                }

                // write powerwball to console
                Console.WriteLine("PowerBall = {0:D2}", pBall);
            } // end for loop

            // prompt user to play again
            Console.Write("Do you want to play again?: ");
            input = Console.ReadLine();
            if (input.Equals("maybe", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Write("Think about it. Do you really want to win?: ");
                input = Console.ReadLine();
            }
        // run again as long as input equals yes
        } while (input.Equals("yes", StringComparison.InvariantCultureIgnoreCase));
        
        // nifty goodbye sleep function
        Console.WriteLine("Goodbye!");
        Thread.Sleep(1000);
        Console.WriteLine("......");
        Thread.Sleep(1000);
        Console.WriteLine(".....");
        Thread.Sleep(1000);
        Console.WriteLine("....");
        Thread.Sleep(1000);
        Console.WriteLine("...");
        Thread.Sleep(1000);
        Console.WriteLine("..");
        Thread.Sleep(1000);
        Console.WriteLine(".");
        Thread.Sleep(300);
    } // end main
} // end class PowerBall
