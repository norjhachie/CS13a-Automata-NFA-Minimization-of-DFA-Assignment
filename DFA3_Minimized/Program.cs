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
                Console.Write("Enter a string of a and b (or 'exit' to quit): ");
                string input = (Console.ReadLine() ?? "").Trim();

                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }

                if (!IsValidInput(input))
                {
                    Console.WriteLine("Invalid input! Please enter only a and b.");
                    Console.WriteLine();
                    continue;
                }

                string state = "AD";

                foreach (char symbol in input)
                {
                    state = GetNextState(state, symbol);
                }

                Console.WriteLine($"Final state: {state}");
                Console.WriteLine(state == "E" ? "ACCEPTED" : "REJECTED");
                Console.WriteLine();
            }
        }

        // Minimized DFA 3
        // Accepts strings ending with "ab"

        static string GetNextState(string state, char symbol)
        {
            switch (state)
            {
                case "AD":
                    return symbol == 'a' ? "C" : "B";

                case "B":
                    return symbol == 'a' ? "C" : "B";

                case "C":
                    return symbol == 'a' ? "C" : "E";

                case "E":
                    return symbol == 'a' ? "C" : "B";

                default:
                    return "AD";
            }
        }

        static bool IsValidInput(string input)
        {
            foreach (char symbol in input)
            {
                if (symbol != 'a' && symbol != 'b')
                    return false;
            }

            return true;
        }
    }
}

