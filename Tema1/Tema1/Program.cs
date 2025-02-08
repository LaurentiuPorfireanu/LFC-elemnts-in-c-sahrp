using System;
using Tema1;

class Program
{

    public static void WriteAutomatonToFile(DeterministicFiniteAutomaton dfa, string outputPath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.WriteLine("Deterministic Finite Automaton:");
                writer.WriteLine("States: " + string.Join(", ", dfa.States));
                writer.WriteLine("Alphabet: " + string.Join(", ", dfa.Alphabet));
                writer.WriteLine("Initial State: " + dfa.InitialState);
                writer.WriteLine("Final States: " + string.Join(", ", dfa.FinalStates));
                writer.WriteLine("Transition Function:");
                foreach (var transition in dfa.TransitionFunction)
                {
                    writer.WriteLine($"δ({transition.Key.Item1}, {transition.Key.Item2}) -> {transition.Value}");
                }
            }
            Console.WriteLine($"The automaton was saved to the file: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to file: {ex.Message}");
        }
    }
    public static string ReadRegexFromFile(string filePath)
    {
        try
        {
            return File.ReadAllText(filePath).Trim();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading the file: {ex.Message}");
            return null;
        }
    }
    public static bool IsValidRegex(string regex)
    {

        if (!RegexProcessor.ContainsOnlyValidCharacters(regex))
        {
            Console.WriteLine("The regex contains invalid characters.");
            return false;
        }


        if (!RegexProcessor.AreParenthesesBalanced(regex))
        {
            Console.WriteLine("The regex has unbalanced parentheses.");
            return false;
        }


        if (!RegexProcessor.AreOperatorsValid(regex))
        {
            Console.WriteLine("The regex has invalid operator placement.");
            return false;
        }


        return true;
    }


    static void Main(string[] args)
    {
        string filePath = "regex.txt";
        string outputFilePath = "automaton_output.txt";
        string regex = ReadRegexFromFile(filePath);


        if (!IsValidRegex(regex))
        {
            Console.WriteLine("Invalid regular expression. Exiting.");
            return;
        }

        string rpn = RegexProcessor.ConvertToRPN(regex);
        Console.WriteLine($"Postfix Notation (RPN): {rpn}");


        var lambdaAutomaton = LambdaAutomaton.BuildFromRPN(rpn);
        lambdaAutomaton.SaveAlphabet();
        var dfa = lambdaAutomaton.ConvertToDFA();
        dfa.SaveAlphabet();


        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Print Lambda Automaton");
            Console.WriteLine("2. Print Deterministic Finite Automaton (DFA)");
            Console.WriteLine("3. Check if a word is accepted by the DFA");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    lambdaAutomaton.PrintAutomaton();
                    break;

                case "2":
                    dfa.PrintAutomaton();
                    WriteAutomatonToFile(dfa, outputFilePath);
                    break;

                case "3":
                    Console.Write("Enter a word to check: ");
                    string word = Console.ReadLine();
                    bool isAccepted = dfa.CheckWord(word);
                    Console.WriteLine(isAccepted ? "The word is accepted." : "The word is rejected.");
                    break;

                case "4":
                    Console.WriteLine("Exiting program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    
}

