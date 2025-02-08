using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    internal class RegexProcessor
    {
        public static string ConvertToRPN(string equation)
        {

            Stack<char> operators = new();
            string rpn = string.Empty;

            string explicitConcatenation = AddExplicitConcatenation(equation);
            Console.WriteLine($"Expresion after adding the concatenation: {explicitConcatenation}");


            foreach (char c in explicitConcatenation)
            {
                if(char.IsLetterOrDigit(c))
                    rpn+= c;
                else
                    if(c=='(')
                    operators.Push(c);
                else
                    if (c == ')')
                    HandleClosingParenthesis(operators, ref rpn);
                else
                    HandleOperator(c, operators, ref rpn);
            }

            while(operators.Count > 0)
            {
                rpn += operators.Pop();
            }
            return rpn;
        }
    
        public static string AddExplicitConcatenation(string equation)
        {
            StringBuilder result = new();
            for (int i = 0; i < equation.Length; i++)
            {
                char currentChar = equation[i];
                result.Append(currentChar);

                if (i + 1 < equation.Length)
                {
                    char next = equation[i + 1];

                    if ((char.IsLetterOrDigit(currentChar) || currentChar == ')' || currentChar == '*')
                        && (char.IsLetterOrDigit(next) || next == '('))
                    {
                        result.Append('.');
                    }
                }
            }
            return result.ToString();
        }

        private static void HandleClosingParenthesis(Stack<char> operators,ref string rpn)
        {
            while(operators.Count > 0 && operators.Peek() != '(')
            {
                rpn += operators.Pop();
            }
            if(operators.Count > 0)
                operators.Pop();
        }
        private static void HandleOperator(char c, Stack<char> operators, ref string rpn)
        {
            while (operators.Count > 0 && Priority(operators.Peek()) >= Priority(c))
            {
                rpn += operators.Pop();
            }
            operators.Push(c);
        }

        private static int Priority(char c)
        {
           switch (c)
           {
                case '(':
                    return 0;
                case ')':
                    return 0;
                case '|':
                    return 1;
                case '.':
                    return 2;
                case '*':
                    return 3;
                default:
                    return 0;
            }
        }

       

        public static bool ContainsOnlyValidCharacters(string regex)
        {
            foreach (char c in regex)
            {
                if (!char.IsLetterOrDigit(c) && c != '|' && c != '*' && c != '.' && c != '(' && c != ')')
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AreParenthesesBalanced(string regex)
        {
            Stack<char> stack = new();
            foreach (char c in regex)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    stack.Pop();
                }
            }
            return stack.Count == 0;
        }

        public static bool AreOperatorsValid(string regex)
        {
            char? previous = null;
            foreach (char current in regex)
            {
                if (previous != null)
                {
                    if ((previous == '.' || previous == '|') && (current == '.' || current == '|' || current == ')'))
                    {
                        return false;
                    }
                    if (previous == '(' && (current == '|' || current == '*' || current == ')'))
                    {
                        return false;
                    }
                }
                previous = current;
            }
            return previous != '|' && previous != '.';
        }


        
    }
}
