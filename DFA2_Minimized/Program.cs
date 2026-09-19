using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFA2_Minimized
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Write("Enter a string of 0s and 1s (or type 'exit' to stop): ");
                string input = Console.ReadLine();

                // Exit condition
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Program stopped.");
                    break;
                }

                string state = "AB";
                bool validInput = true;

                foreach (char symbol in input)
                {
                    if (symbol != '0' && symbol != '1')
                    {
                        Console.WriteLine("Invalid input! Please enter only 0 and 1.");
                        validInput = false;
                        break;
                    }

                    switch (state)
                    {
                        case "AB":
                            if (symbol == '0')
                                state = "AB";
                            else
                                state = "CDE";
                            break;

                        case "CDE":
                            if (symbol == '0')
                                state = "CDE";
                            else
                                state = "F";
                            break;

                        case "F":
                            state = "F";
                            break;
                    }
                }

                // Display result only if input is valid
                if (validInput)
                {
                    Console.WriteLine("Final State: " + state);

                    if (state == "CDE")
                    {
                        Console.WriteLine("ACCEPTED");
                    }
                    else
                    {
                        Console.WriteLine("REJECTED");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
