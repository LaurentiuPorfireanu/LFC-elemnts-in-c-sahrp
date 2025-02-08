using System;
using System.IO;
using Antlr4.Runtime;
namespace Tema2
{
    public class LexerHandler
    {
        private readonly string _inputFilePath;
        private readonly string _outputFilePath;

        public LexerHandler(string inputFilePath, string outputFilePath)
        {
            _inputFilePath = inputFilePath;
            _outputFilePath = outputFilePath;
        }

        public void ProcessLexicalUnits()
        {
            if (!File.Exists(_inputFilePath))
            {
                Console.WriteLine($"Error: File not found at {_inputFilePath}");
                return;
            }

            try
            {
                string sourceCode = File.ReadAllText(_inputFilePath);
                AntlrInputStream inputStream = new AntlrInputStream(sourceCode);
                MygrammerLexer lexer = new MygrammerLexer(inputStream);

                using (StreamWriter writer = new StreamWriter(_outputFilePath))
                {
                    writer.WriteLine("Token, Lexeme, Line");

                    var token = lexer.NextToken();
                    while (token.Type != Antlr4.Runtime.TokenConstants.EOF)
                    {
                        string tokenName = lexer.Vocabulary.GetSymbolicName(token.Type);
                        string lexeme = token.Text;
                        int line = token.Line;

                        writer.WriteLine($"{tokenName}, {lexeme}, {line}");
                        token = lexer.NextToken();
                    }
                }

                Console.WriteLine($"Lexical units saved to {_outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}
