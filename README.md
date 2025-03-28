# LFC-elemnts-in-c#

This repository showcases two educational projects in C#, focused on fundamental concepts in formal languages and compiler design. It is aimed at students or enthusiasts looking to understand how regular expressions can be used to build automata, and how compilers process and analyze source code.


1. DFA from Regular Expression
    This project illustrates the procedure to build a Deterministic Finite Automaton (DFA) based on a specified regular expression, imitating the function of lexical analyzers in compilers.
    Features:
       -Parses a regular expression input.
       -Constructs a syntax tree for the regex.
       -Builds a DFA transition table based on the syntax tree.
       -Allows testing of input strings against the generated DFA.
   
   This implementation provides a step-by-step view of the algorithm used in converting regex patterns into a DFA, making it a powerful learning tool for automata theory.

2. Basic Compiler
    The second project is a minimal yet functional compiler that simulates key parts of a front-end compiler pipeline.
    Features:
        -Comment Elimination: Removes both single-line and multi-line comments from the source code, imitating the operation of          lexical analyzers in compilers.
        -Lexical Analysis: Breaks input into tokens
        -Error Detection: Catches syntax and lexical errors such as invalid tokens, unclosed strings, or misplaced characters.
        -Token Classification: Recognizes types, keywords, literals, operators, and symbols.
