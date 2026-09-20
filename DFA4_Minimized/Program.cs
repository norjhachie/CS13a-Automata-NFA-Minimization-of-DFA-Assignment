using System;


namespace DFA4_Minimized
{
    internal class Program
    {
        static void Main(string[] args)
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

                string state = "A";
                bool validInput = true;

                // Process each character
                foreach (char symbol in input)
                {
                    if (symbol == 'a')
                    {
                        if (state == "A")
                        {
                            state = "C";
                        }
                        else if (state == "B")
                        {
                            state = "DE";
                        }
                        else if (state == "C")
                        {
                            state = "C";
                        }
                        else if (state == "DE")
                        {
                            state = "DE";
                        }
                    }
                    else if (symbol == 'b')
                    {
                        if (state == "A")
                        {
                            state = "B";
                        }
                        else if (state == "B")
                        {
                            state = "B";
                        }
                        else if (state == "C")
                        {
                            state = "C";
                        }
                        else if (state == "DE")
                        {
                            state = "B";
                        }
                    }
                    else
                    {
                        validInput = false;
                        break;
                    }
                }

                if (!validInput)
                {
                    Console.WriteLine("Invalid input! Please enter only a's and b's.");
                }
                else if (state == "DE")
                {
                    Console.WriteLine("Accepted!");
                }
                else
                {
                    Console.WriteLine("Rejected!");
                }

                Console.WriteLine();
            }
        }
    }
}
