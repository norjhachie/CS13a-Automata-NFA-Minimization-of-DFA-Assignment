using System;
using System.Collections.Generic;

class NFACsharpComment
{
    // States:
    // q0 = start state
    // q1 = after reading first '/'
    // q2 = after reading '/'
    // q3 = inside the comment
    // q4 = saw '*' and waiting for '/'
    // q5 = accepting state

    static HashSet<int> EpsilonClosure(HashSet<int> states)
    {
        HashSet<int> closure = new HashSet<int>(states);
        Stack<int> stack = new Stack<int>(states);

        while (stack.Count > 0)
        {
            int state = stack.Pop();

            // q0 --ε--> q1
            if (state == 0 && !closure.Contains(1))
            {
                closure.Add(1);
                stack.Push(1);
            }
        }

        return closure;
    }

    static HashSet<int> Move(HashSet<int> states, char input)
    {
        HashSet<int> nextStates = new HashSet<int>();

        foreach (int state in states)
        {
            switch (state)
            {
                // q1 --/--> q2
                case 1:
                    if (input == '/')
                    {
                        nextStates.Add(2);
                    }
                    break;

                // q2 --*--> q3
                case 2:
                    if (input == '*')
                    {
                        nextStates.Add(3);
                    }
                    break;

                // q3 is inside the comment
                case 3:

                    // q3 --a--> q3
                    if (input == 'a')
                    {
                        nextStates.Add(3);
                    }

                    // q3 --/--> q3
                    if (input == '/')
                    {
                        nextStates.Add(3);
                    }

                    // q3 --*--> q3
                    // q3 --*--> q4
                    // This is the nondeterministic transition.
                    if (input == '*')
                    {
                        nextStates.Add(3);
                        nextStates.Add(4);
                    }

                    break;

                // q4 --/--> q5
                case 4:
                    if (input == '/')
                    {
                        nextStates.Add(5);
                    }
                    break;

                // q5 is the accepting state.
                case 5:
                    break;
            }
        }

        return nextStates;
    }

    static bool IsAccepted(string input)
    {
        // Start at q0
        HashSet<int> currentStates =
            EpsilonClosure(new HashSet<int> { 0 });

        // Read each character
        foreach (char symbol in input)
        {
            currentStates = Move(currentStates, symbol);

            // Apply epsilon transitions
            currentStates = EpsilonClosure(currentStates);

            // No possible state means reject
            if (currentStates.Count == 0)
            {
                return false;
            }
        }

        // Accept only if q5 is reached
        return currentStates.Contains(5);
    }

    static void Main()
    {
        string[] accepted =
        {
            "/*a*/",
            "/**/",
            "/***/",
            "/*aaa*aaa*/",
            "/*a/a*/"
        };

        string[] rejected =
        {
            "/**",
            "/**/a/*aa*/",
            "aaa/**/aa",
            "/*/",
            "/**a/",
            "//aaaa"
        };

        Console.WriteLine("===== ACCEPTED STRINGS =====");

        foreach (string test in accepted)
        {
            Console.WriteLine(
                $"{test,-20} -> {(IsAccepted(test) ? "ACCEPT" : "REJECT")}"
            );
        }

        Console.WriteLine();

        Console.WriteLine("===== REJECTED STRINGS =====");

        foreach (string test in rejected)
        {
            Console.WriteLine(
                $"{test,-20} -> {(IsAccepted(test) ? "ACCEPT" : "REJECT")}"
            );
        }
    }
}