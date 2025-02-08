using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace Tema2
{
    public class ErrorHandler : BaseErrorListener
    {
        public override void SyntaxError(
            TextWriter output,
            IRecognizer recognizer,
            IToken offendingSymbol,
            int line,
            int charPositionInLine,
            string msg,
            RecognitionException e)
        {
            Console.WriteLine($"Syntax Error at line {line}, position {charPositionInLine}: {msg}");
        }
    }
}
