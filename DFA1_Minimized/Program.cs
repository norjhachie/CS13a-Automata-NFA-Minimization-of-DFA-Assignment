using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFA1_Minimized
{
    internal class Program
    {
  
            static void Main()
            {
                while (true)
                {
                    Console.Write("Enter a string of 0s and 1s (or type 'exit' to stop): ");
                    string input = Console.ReadLine();

                    // Exit the loop if user types "exit"
                    if (input.ToLower() == "exit")
                    {
                        Console.WriteLine("Program stopped.");
                        break;
                    }

                    string state = "AC";
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
                            case "AC":
                                if (symbol == '0')
                                    state = "B";
                                else
                                    state = "AC";
                                break;

                            case "B":
                                if (symbol == '0')
                                    state = "B";
                                else
                                    state = "D";
                                break;

                            case "D":
                                if (symbol == '0')
                                    state = "B";
                                else
                                    state = "E";
                                break;

                            case "E":
                                if (symbol == '0')
                                    state = "B";
                                else
                                    state = "AC";
                                break;
                        }
                    }

                    // Skip final state checking if input was invalid
                    if (!validInput)
                    {
                        continue;
                    }

                    Console.WriteLine("Final State: " + state);

                    if (state == "E")
                    {
                        Console.WriteLine("ACCEPTED");
                    }
                    else
                    {
                        Console.WriteLine("REJECTED");
                    }

                    Console.WriteLine();
                }
            }
     
    }
}
