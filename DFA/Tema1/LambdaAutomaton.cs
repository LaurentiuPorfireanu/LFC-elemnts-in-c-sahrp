using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tema1;

namespace Tema1
{
    internal class LambdaAutomaton
    {

        public HashSet<string> States { get; set; } = new();
        public HashSet<char> Alphabet { get; set; } = new();
        public List<(string, char?, string)> Transitions { get; set; } = new();
        public string InitialState { get; set; }
        public string FinalState { get; set; } 

      



        

        public static LambdaAutomaton BuildFromRPN(string rpn)
        {
            Stack<LambdaAutomaton> stack = new();
            int stateCounter = 0;

            foreach(var c in rpn)
            {
                if (char.IsLetterOrDigit(c))
                    stack.Push(CreateBaseAutomatopn(c, ref stateCounter));
                else
                    stack.Push(HandleOperators(c, stack, ref stateCounter));
            }
            return stack.Pop();
        }
        public void SaveAlphabet()
        {
            Alphabet.Clear(); 

            foreach (var transition in Transitions)
            {
                if (transition.Item2.HasValue) 
                {
                    Alphabet.Add((char)transition.Item2.Value);
                }
            }
        }

        private void PrintStates()
        {
            Console.WriteLine("\nStates:\n");
            foreach (var state in States)
            {
                Console.Write(state + ',');
            }
        }
        private void PrintAlphabet()
        {
            Console.WriteLine("\nAlphabet (Σ):\n");
            foreach (var letter in Alphabet)
            {
                Console.Write(letter + ',');
            }
        }
        private void PrintTransitionFunction()
        {
            Console.WriteLine("\nTransition Function e(δ):\n");
            foreach (var (from, symbol, to) in Transitions)
            {
                string transition = symbol == null ? "lambda" : symbol.ToString();
                Console.WriteLine($"δ({from}, {transition}) -> {to}");
            }
        }



        private void PrintSpecialStates()
        {
            Console.WriteLine("\nInitial State (q0): " + InitialState);
            Console.WriteLine("\nFinal States (F): " + string.Join(", ", FinalState));
        }

        public void PrintAutomaton()
        {
            Console.WriteLine($"The NFA has {States.Count} states {Transitions.Count} transitons.");
            SaveAlphabet();
            PrintStates();
            PrintAlphabet();
            PrintSpecialStates();
            PrintTransitionFunction();



        }

        private static LambdaAutomaton CreateBaseAutomatopn(char c, ref int stateCounter)
        {
            var automaton = new LambdaAutomaton();
            string start= $"q{stateCounter++}";
            string end = $"q{stateCounter++}";
            automaton.States.Add(start);
            automaton.States.Add(end);
            automaton.Alphabet.Add(c);
            automaton.InitialState = start;
            automaton.FinalState=end;
            automaton.Transitions.Add((start, c, end));
            return automaton;
        }

        private static LambdaAutomaton HandleOperators(char op, Stack<LambdaAutomaton> stack, ref int counter)
        {
            switch (op)
            {
                case '|':
                    var b = stack.Pop();
                    var a = stack.Pop();
                    return Alternation(a,b, ref counter);
                case '.':
                     b = stack.Pop();
                     a = stack.Pop();
                    return Concatenation(a, b); 
                case '*':
                    a = stack.Pop();
                    return KleeneStar(a, ref counter);
                default:
                    throw new ArgumentException("Operator necunoscut");
            }
        }


        private static LambdaAutomaton Alternation(LambdaAutomaton a, LambdaAutomaton b, ref int counter)
        {
           var result = new LambdaAutomaton();
            string start = $"q{counter++}";
            string end = $"q{counter++}";
            result.States.UnionWith(a.States);
            result.States.UnionWith(b.States);
            result.States.UnionWith(new[] { start, end });
            result.Transitions.AddRange(a.Transitions);
            result.Transitions.AddRange(b.Transitions);
            result.Transitions.AddRange(new[] 
            { (start,(char?)null, a.InitialState),
                (start, null, b.InitialState) ,
                (a.FinalState,(char?)null,end),
                (b.FinalState,(char?)null,end)
            });
            result.InitialState = start;
            result.FinalState = end;
            return result;
        }



        private static LambdaAutomaton Concatenation(LambdaAutomaton a, LambdaAutomaton b)
        {
            
            string stateToMerge = b.InitialState;
            string stateToKeep = a.FinalState;

            
            for (int i = 0; i < b.Transitions.Count; i++)
            {
                var (from, symbol, to) = b.Transitions[i];

                if (from == stateToMerge)
                    b.Transitions[i] = (stateToKeep, symbol, to);

                if (to == stateToMerge)
                    b.Transitions[i] = (from, symbol, stateToKeep);
            }

            
            b.States.Remove(stateToMerge);

            
            var result = new LambdaAutomaton
            {
                InitialState = a.InitialState,
                FinalState = b.FinalState
            };

            
            result.States.UnionWith(a.States);
            result.States.UnionWith(b.States);
            result.Transitions.AddRange(a.Transitions);
            result.Transitions.AddRange(b.Transitions);

            return result;
        }


        private static LambdaAutomaton KleeneStar(LambdaAutomaton a, ref int counter)
        {
            var result = new LambdaAutomaton();
            string start = $"q{counter++}";
            string end = $"q{counter++}";
            result.States.UnionWith(a.States);
            result.States.UnionWith(new[] { start, end });
            result.Transitions.AddRange(a.Transitions);
            result.Transitions.AddRange(new[]
            {
                (start, (char?)null, a.InitialState),
                (start, (char?)null, end),
                (a.FinalState, (char?)null, a.InitialState),
                (a.FinalState, (char?)null, end)
            });
            result.InitialState = start;
            result.FinalState = end;
            return result;
        }

        private HashSet<string> EpsilonClosure(HashSet<string> states)
        {
            var closure = new HashSet<string>(states);
            var stack = new Stack<string>(states);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                foreach (var (from, symbol, to) in Transitions)
                {
                    if (from == current && symbol == null && !closure.Contains(to))
                    {
                        closure.Add(to);
                        stack.Push(to);
                    }
                }
            }

            return closure;
        }

        public DeterministicFiniteAutomaton ConvertToDFA()
        {
            var dfa = new DeterministicFiniteAutomaton();
            var stateMapping = new Dictionary<HashSet<string>, string>(HashSet<string>.CreateSetComparer());
            var queue = new Queue<HashSet<string>>();

            var initialClosure = EpsilonClosure(new HashSet<string> { InitialState });
            var initialStateName = $"DFA_{stateMapping.Count}";
            stateMapping[initialClosure] = initialStateName;
            dfa.States.Add(initialStateName);
            dfa.InitialState = initialStateName;
            queue.Enqueue(initialClosure);

            if (initialClosure.Contains(FinalState))
                dfa.FinalStates.Add(initialStateName);

            while (queue.Count > 0)
            {
                var currentSet = queue.Dequeue();
                var currentStateName = stateMapping[currentSet];

                foreach (var symbol in Alphabet)
                {
                    
                    var reachableStates = new HashSet<string>();

                    foreach (var state in currentSet)
                    {
                        foreach (var (from, transitionSymbol, to) in Transitions)
                        {
                            if (from == state && transitionSymbol == symbol)
                                reachableStates.UnionWith(EpsilonClosure(new HashSet<string> { to }));
                        }
                    }

                    if (reachableStates.Count == 0)
                        continue;
               
                    if (!stateMapping.ContainsKey(reachableStates))
                    {
                        var newStateName = $"DFA_{stateMapping.Count}";
                        stateMapping[reachableStates] = newStateName;
                        dfa.States.Add(newStateName);

                        if (reachableStates.Contains(FinalState))
                            dfa.FinalStates.Add(newStateName);

                        queue.Enqueue(reachableStates);
                    }                    
                    dfa.TransitionFunction[(currentStateName, symbol)] = stateMapping[reachableStates];
                }
            }
            dfa.Alphabet = new HashSet<char>(Alphabet);
            return dfa;
        }   
    }
}
