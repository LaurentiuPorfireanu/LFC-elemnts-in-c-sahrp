using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Tema2
{
    public class SyntaxHandler
    {
        private readonly MygrammerParser.ProgramContext _programContext;

        public SyntaxHandler(MygrammerParser.ProgramContext programContext)
        {
            _programContext = programContext;
        }

        public void ExtractGlobalVariables(string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("Global Variables:");
                foreach (var declaration in _programContext.declaration())
                {
                    if (declaration.Parent is MygrammerParser.ProgramContext) // Ensure it's top-level
                    {
                        var type = declaration.type().GetText();
                        var name = declaration.ID().GetText();
                        var value = declaration.expression()?.GetText() ?? "null";

                        writer.WriteLine($"{type} {name} = {value}");
                    }
                }
            }

            Console.WriteLine($"Global variables saved to {outputFilePath}");
        }

        public void ExtractFunctions(string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("Functions:");

                foreach (var function in _programContext.functionDeclaration())
                {
                    // Extract return type, function name, and parameters
                    var returnType = function.type().GetText();
                    var functionName = function.ID().GetText();
                    var parameters = new List<string>();

                    // Extract parameters
                    if (function.parameterList() != null)
                    {
                        var paramList = function.parameterList();
                        for (int i = 0; i < paramList.ChildCount; i += 3) // Increment by 3: type, ID, comma
                        {
                            if (paramList.GetChild(i) != null && paramList.GetChild(i + 1) != null)
                            {
                                var type = paramList.GetChild(i).GetText();
                                var name = paramList.GetChild(i + 1).GetText();
                                parameters.Add($"{type} {name}");
                            }
                        }
                    }
                    var formattedParameters = parameters.Count > 0 ? string.Join(", ", parameters) : "None";

                    // Check for recursion and function type
                    var functionType = "iterative";
                    if (function.statement().Any(stmt => stmt.GetText().Contains(functionName)))
                    {
                        functionType = "recursive";
                    }
                    if (functionName == "main")
                    {
                        functionType = "main";
                    }

                    // Extract local variables
                    var localVariables = new List<string>();
                    foreach (var stmt in function.statement())
                    {
                        ExtractLocalVariablesFromStatement(stmt, localVariables);
                    }

                    // Extract control structures
                    var controlStructures = new List<string>();
                    foreach (var stmt in function.statement())
                    {
                        if (stmt.ifStatement() != null)
                        {
                            controlStructures.Add("if-else");
                        }
                        else if (stmt.forStatement() != null)
                        {
                            controlStructures.Add("for");
                        }
                        else if (stmt.whileStatement() != null)
                        {
                            controlStructures.Add("while");
                        }
                    }
                    var formattedControlStructures = controlStructures.Count > 0
                        ? string.Join(", ", controlStructures.Distinct())
                        : "None";

                    // Write all details to the file
                    writer.WriteLine($"Function: {functionName}");
                    writer.WriteLine($"  Type: {functionType}");
                    writer.WriteLine($"  Return Type: {returnType}");
                    writer.WriteLine($"  Parameters: {formattedParameters}");
                    writer.WriteLine($"  Local Variables: {(localVariables.Count > 0 ? string.Join(", ", localVariables) : "None")}");
                    writer.WriteLine($"  Control Structures: {formattedControlStructures}");
                    writer.WriteLine();
                }
            }

            Console.WriteLine($"Functions saved to {outputFilePath}");
        }

        // Helper method to extract local variables
        private void ExtractLocalVariablesFromStatement(MygrammerParser.StatementContext stmt, List<string> localVariables)
        {
            if (stmt.block() != null) // If statement is a block
            {
                foreach (var blockStmt in stmt.block().statement())
                {
                    ExtractLocalVariablesFromStatement(blockStmt, localVariables);
                }
            }

            if (stmt.forStatement() != null) // If statement is a for loop
            {
                var forStmt = stmt.forStatement();
                if (forStmt.declaration() != null) // Check for declaration in for loop
                {
                    var localVar = forStmt.declaration();
                    var type = localVar.type().GetText();
                    var name = localVar.ID().GetText();
                    var value = localVar.expression()?.GetText() ?? "null";
                    localVariables.Add($"{type} {name} = {value}");
                }
            }
        }


    }
}
