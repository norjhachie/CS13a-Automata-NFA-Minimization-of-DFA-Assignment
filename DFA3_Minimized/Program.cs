using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFA3_Minimized
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Write("Enter a string of a's and b's (or type 'exit' to stop): ");
                string input = Console.ReadLine();

                // Exit the program
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Program stopped.");
                    break;
                }

                string state = "X";
                bool validInput = true;

                // Process each character
                foreach (char symbol in input)
                {
                    if (symbol == 'a')
                    {
                        // DFA transitions for 'a'
                        if (state == "X")
                            state = "Y";
                        else if (state == "Y")
                            state = "Y";
                        else if (state == "Z")
                            state = "Y";
                    }
                    else if (symbol == 'b')
                    {
                        // DFA transitions for 'b'
                        if (state == "X")
                            state = "X";
                        else if (state == "Y")
                            state = "Z";
                        else if (state == "Z")
                            state = "X";
                    }
                    else
                    {
                        validInput = false;
                        break;
                    }
                }

                // Check if the input is valid
                if (!validInput)
                {
                    Console.WriteLine("Invalid input! Please enter only a's and b's.");
                }
                else
                {
                    // Z is the accepting state
                    if (state == "Z")
                    {
                        Console.WriteLine("Accepted!");
                    }
                    else
                    {
                        Console.WriteLine("Rejected!");
                    }
                }

                Console.WriteLine();
            }

        }
    }
}

