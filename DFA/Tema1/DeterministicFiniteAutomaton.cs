using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    internal class DeterministicFiniteAutomaton
    {
        public HashSet<string> States { get; set; } = new();
        public HashSet<char> Alphabet { get; set; } = new();
        public Dictionary<(string, char), string> TransitionFunction { get; set; } = new();
        public string InitialState { get; set; }
        public HashSet<string> FinalStates { get; set; } = new();


        private bool StateIsNUll()
        {
            return States.Count == 0;
        }

        private bool AlphabetIsNull()
        {
            return Alphabet.Count == 0;
        }
        private bool InisialStateIsNull()
        {
            return !States.Contains(InitialState);
        }

        private bool IsDeterministic()
        {
            var seenTransitions = new HashSet<(string, char)>();

            foreach (var transition in TransitionFunction)
            {
                if (!seenTransitions.Add(transition.Key))
                {
                    return false;
                }
            }

            return true;
        }


        private bool StatesOverlapsAlphabet()
        {
            foreach (var state in States)
            {
                if (Alphabet.Contains(state[0])) 
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasValidInitialTransition()
        {
            foreach(var symbol in Alphabet)
            {
                if (TransitionFunction.ContainsKey((InitialState, symbol)))
                    return true;
            }
            return false;
        }

        private bool ValidTransitons()
        {
            foreach(var transition in TransitionFunction)
            {
                var satate = transition.Key.Item1;
                var symbol = transition.Key.Item2;

                if(!States.Contains(satate) || !Alphabet.Contains(symbol) )
                {
                    return false;
                }
            }
            return true;
        }

        public bool VerifyAutomaton()
        {
            if (StateIsNUll())
            {
                Console.WriteLine("Error: The automaton has no defined states.");
                return false;
            }

            if (AlphabetIsNull())
            {
                Console.WriteLine("Error: The alphabet (Σ) is not defined.");
                return false;
            }

            if (InisialStateIsNull())
            {
                Console.WriteLine("Error: The initial state does not belong to the set of states.");
                return false;
            }

            if (!IsDeterministic())
            {
                Console.WriteLine("Error: The transition function is not deterministic (duplicate transitions exist).");
                return false;
            }

            if (StatesOverlapsAlphabet())
            {
                Console.WriteLine("Error: There are symbols in the alphabet that overlap with state names.");
                return false;
            }

            if (!HasValidInitialTransition())
            {
                Console.WriteLine("Error: The initial state does not have any valid transitions.");
                return false;
            }

            if (!ValidTransitons())
            {
                Console.WriteLine("Error: There are transitions using invalid symbols or states.");
                return false;
            }

            Console.WriteLine("The automaton is valid.");
            return true;
        }






      
        private void PrintStates()
        {
            Console.WriteLine("States:\n");
            foreach (var state in States)
            {
                Console.Write(state);
                Console.Write(',');
            }
        }

        private void PrintAlphabet()
        {
            Console.WriteLine("\nAlphabet (Σ):\n");
            foreach (var letter in Alphabet)
            {
                Console.Write(letter);
                Console.Write(',');

            }
        }


        private void PrintTransitionFunction()
        {
            Console.WriteLine("\nTransition Function (δ):\n");
            foreach (var transition in TransitionFunction)
            {
                Console.WriteLine($"δ({transition.Key.Item1},{transition.Key.Item2})={transition.Value}");
            }
        }

        private void PrintSpecialStates()
        {
            Console.WriteLine("\nInitial State (q0): " + InitialState);
            Console.WriteLine("\nFinal States (F): " + string.Join(", ", FinalStates));
        }

        public void SaveAlphabet()
        {
            Alphabet.Clear(); 

            foreach (var transition in TransitionFunction)
            {
                Alphabet.Add(transition.Key.Item2); 
            }
        }

        public void PrintAutomaton()
        {
            if (VerifyAutomaton())
            {
                SaveAlphabet();
                PrintStates();
                PrintAlphabet();
                PrintSpecialStates();
                PrintTransitionFunction();
               
            }
            else
            {
                Console.WriteLine("The automaton is not valid.");
            }
        }
        public bool CheckWord(string word)
        {
            var currentState = InitialState;
            foreach (var letter in word)
            {
                if (!Alphabet.Contains(letter)|| !TransitionFunction.ContainsKey((currentState, letter)))
                {
                    return false;
                }
               
                currentState = TransitionFunction[(currentState, letter)];
            }
            return FinalStates.Contains(currentState);
        }

       
        
    }
}
