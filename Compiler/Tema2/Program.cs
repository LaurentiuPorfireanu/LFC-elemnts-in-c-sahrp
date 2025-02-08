using System;
using Antlr4.Runtime;
using Tema2;

public class Compiler
{
    static void Main(string[] args)
    {
        string inputFilePath = "source_test.txt";
        string lexicalOutputPath = "lexical_units.txt";
        string globalVarsOutputPath = "global_variables.txt";
        string functionsOutputPath = "functions.txt";

        // Step 1: Process Lexical Units
        LexerHandler lexerHandler = new LexerHandler(inputFilePath, lexicalOutputPath);
        lexerHandler.ProcessLexicalUnits();

        // Step 2: Parse the Program
        try
        {
            string sourceCode = File.ReadAllText(inputFilePath);
            AntlrInputStream inputStream = new AntlrInputStream(sourceCode);
            MygrammerLexer lexer = new MygrammerLexer(inputStream);
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            MygrammerParser parser = new MygrammerParser(tokenStream);

            // Add custom error listener
            parser.RemoveErrorListeners();
            parser.AddErrorListener(new ErrorHandler());

            var programContext = parser.program();
            SyntaxHandler syntaxHandler = new SyntaxHandler(programContext);

            // Step 3: Extract and Save Syntax Elements
            syntaxHandler.ExtractGlobalVariables(globalVarsOutputPath);
            syntaxHandler.ExtractFunctions(functionsOutputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
