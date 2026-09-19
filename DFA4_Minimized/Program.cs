using System;


namespace DFA4_Minimized
{
    internal class Program
    {
        static void Main(string[] args)
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

                string state = "AB"; // Start state

                foreach (char symbol in input)
                {
                    state = GetNextState(state, symbol);
                }

                Console.WriteLine($"Final state: {state}");
                Console.WriteLine(state == "CF" ? "ACCEPTED" : "REJECTED");
                Console.WriteLine();
            }
        }

        // Minimized DFA 4
        // Accepts strings starting with "a" and ending with "b"

        static string GetNextState(string state, char symbol)
        {
            switch (state)
            {
                case "AB":
                    return symbol == 'a' ? "D" : "AB";

                case "D":
                    return symbol == 'a' ? "D" : "CF";

                case "E":
                    return symbol == 'a' ? "D" : "CF";

                case "CF":
                    return symbol == 'a' ? "D" : "CF";

                default:
                    return "AB";
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
