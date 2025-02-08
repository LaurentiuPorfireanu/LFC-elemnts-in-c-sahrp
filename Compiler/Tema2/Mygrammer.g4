grammar Mygrammer;

// Lexer rules (tokens)

// Keywords
IF: 'if';
ELSE: 'else';
FOR: 'for';
WHILE: 'while';
RETURN: 'return';
INT: 'int';
FLOAT: 'float';
DOUBLE: 'double';
STRING: 'string';
VOID: 'void';

// Operators
PLUS: '+';
MINUS: '-';
MULT: '*';
DIV: '/';
MOD: '%';
LT: '<';
GT: '>';
LE: '<=';
GE: '>=';
EQ: '==';
NE: '!=';
AND: '&&';
OR: '||';
NOT: '!';
ASSIGN: '=';
ADD_ASSIGN: '+=';
SUB_ASSIGN: '-=';
MUL_ASSIGN: '*=';
DIV_ASSIGN: '/=';
MOD_ASSIGN: '%=';
INCREMENT: '++';
DECREMENT: '--';

// Delimiters
LPAREN: '(';
RPAREN: ')';
LBRACE: '{';
RBRACE: '}';
COMMA: ',';
SEMICOLON: ';';

// Literals
NUMERIC_LITERAL: [0-9]+ ('.' [0-9]+)?;
STRING_LITERAL: '"' (~["\r\n])* '"';

// Identifiers
ID: [a-zA-Z_][a-zA-Z0-9_]*;

// Whitespace and Comments
WS: [ \t\r\n]+ -> skip;
LINE_COMMENT: '//' ~[\r\n]* -> skip;
BLOCK_COMMENT: '/*' .*? '*/' -> skip;

// Catch-all for invalid tokens
INVALID: . { throw new RecognitionException("Invalid character: " + getText()); };

// Parser rules (syntax)
program: (declaration | functionDeclaration | statement)* EOF;

declaration: type ID (ASSIGN expression)? SEMICOLON;

functionDeclaration:
	type ID LPAREN parameterList? RPAREN LBRACE statement* RBRACE;

parameterList: type ID (COMMA type ID)*;

statement:
	block
	| ifStatement
	| whileStatement
	| forStatement
	| returnStatement
	| expressionStatement;

block: LBRACE statement* RBRACE;

ifStatement:
	IF LPAREN expression RPAREN statement (ELSE statement)?;

whileStatement: WHILE LPAREN expression RPAREN statement;

forStatement:
	FOR LPAREN (declaration | expressionStatement)? SEMICOLON expression? SEMICOLON expression?
		RPAREN statement;

returnStatement: RETURN expression? SEMICOLON;

expressionStatement: expression? SEMICOLON;

expression: assignment;

assignment:
	ID (
		ASSIGN
		| ADD_ASSIGN
		| SUB_ASSIGN
		| MUL_ASSIGN
		| DIV_ASSIGN
		| MOD_ASSIGN
	) expression
	| logicalOr;

logicalOr: logicalAnd (OR logicalAnd)*;

logicalAnd: equality (AND equality)*;

equality: comparison (EQ comparison | NE comparison)*;

comparison: term (LT term | LE term | GT term | GE term)*;

term: factor (PLUS factor | MINUS factor)*;

factor: unary (MULT unary | DIV unary | MOD unary)*;

unary: (NOT | MINUS)? primary;

primary:
	NUMERIC_LITERAL
	| STRING_LITERAL
	| ID
	| LPAREN expression RPAREN;

type: INT | FLOAT | DOUBLE | STRING | VOID;