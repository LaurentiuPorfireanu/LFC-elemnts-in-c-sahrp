// Generated from c:/Users/laurp/Desktop/Anul 2/LFC/Tema2/Tema2/Mygrammer.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link MygrammerParser}.
 */
public interface MygrammerListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(MygrammerParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(MygrammerParser.ProgramContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#declaration}.
	 * @param ctx the parse tree
	 */
	void enterDeclaration(MygrammerParser.DeclarationContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#declaration}.
	 * @param ctx the parse tree
	 */
	void exitDeclaration(MygrammerParser.DeclarationContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#functionDeclaration}.
	 * @param ctx the parse tree
	 */
	void enterFunctionDeclaration(MygrammerParser.FunctionDeclarationContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#functionDeclaration}.
	 * @param ctx the parse tree
	 */
	void exitFunctionDeclaration(MygrammerParser.FunctionDeclarationContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#parameterList}.
	 * @param ctx the parse tree
	 */
	void enterParameterList(MygrammerParser.ParameterListContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#parameterList}.
	 * @param ctx the parse tree
	 */
	void exitParameterList(MygrammerParser.ParameterListContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterStatement(MygrammerParser.StatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitStatement(MygrammerParser.StatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#block}.
	 * @param ctx the parse tree
	 */
	void enterBlock(MygrammerParser.BlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#block}.
	 * @param ctx the parse tree
	 */
	void exitBlock(MygrammerParser.BlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void enterIfStatement(MygrammerParser.IfStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void exitIfStatement(MygrammerParser.IfStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#whileStatement}.
	 * @param ctx the parse tree
	 */
	void enterWhileStatement(MygrammerParser.WhileStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#whileStatement}.
	 * @param ctx the parse tree
	 */
	void exitWhileStatement(MygrammerParser.WhileStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#forStatement}.
	 * @param ctx the parse tree
	 */
	void enterForStatement(MygrammerParser.ForStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#forStatement}.
	 * @param ctx the parse tree
	 */
	void exitForStatement(MygrammerParser.ForStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#returnStatement}.
	 * @param ctx the parse tree
	 */
	void enterReturnStatement(MygrammerParser.ReturnStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#returnStatement}.
	 * @param ctx the parse tree
	 */
	void exitReturnStatement(MygrammerParser.ReturnStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#expressionStatement}.
	 * @param ctx the parse tree
	 */
	void enterExpressionStatement(MygrammerParser.ExpressionStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#expressionStatement}.
	 * @param ctx the parse tree
	 */
	void exitExpressionStatement(MygrammerParser.ExpressionStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterExpression(MygrammerParser.ExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitExpression(MygrammerParser.ExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#assignment}.
	 * @param ctx the parse tree
	 */
	void enterAssignment(MygrammerParser.AssignmentContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#assignment}.
	 * @param ctx the parse tree
	 */
	void exitAssignment(MygrammerParser.AssignmentContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#logicalOr}.
	 * @param ctx the parse tree
	 */
	void enterLogicalOr(MygrammerParser.LogicalOrContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#logicalOr}.
	 * @param ctx the parse tree
	 */
	void exitLogicalOr(MygrammerParser.LogicalOrContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#logicalAnd}.
	 * @param ctx the parse tree
	 */
	void enterLogicalAnd(MygrammerParser.LogicalAndContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#logicalAnd}.
	 * @param ctx the parse tree
	 */
	void exitLogicalAnd(MygrammerParser.LogicalAndContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#equality}.
	 * @param ctx the parse tree
	 */
	void enterEquality(MygrammerParser.EqualityContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#equality}.
	 * @param ctx the parse tree
	 */
	void exitEquality(MygrammerParser.EqualityContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#comparison}.
	 * @param ctx the parse tree
	 */
	void enterComparison(MygrammerParser.ComparisonContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#comparison}.
	 * @param ctx the parse tree
	 */
	void exitComparison(MygrammerParser.ComparisonContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#term}.
	 * @param ctx the parse tree
	 */
	void enterTerm(MygrammerParser.TermContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#term}.
	 * @param ctx the parse tree
	 */
	void exitTerm(MygrammerParser.TermContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#factor}.
	 * @param ctx the parse tree
	 */
	void enterFactor(MygrammerParser.FactorContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#factor}.
	 * @param ctx the parse tree
	 */
	void exitFactor(MygrammerParser.FactorContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#unary}.
	 * @param ctx the parse tree
	 */
	void enterUnary(MygrammerParser.UnaryContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#unary}.
	 * @param ctx the parse tree
	 */
	void exitUnary(MygrammerParser.UnaryContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#primary}.
	 * @param ctx the parse tree
	 */
	void enterPrimary(MygrammerParser.PrimaryContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#primary}.
	 * @param ctx the parse tree
	 */
	void exitPrimary(MygrammerParser.PrimaryContext ctx);
	/**
	 * Enter a parse tree produced by {@link MygrammerParser#type}.
	 * @param ctx the parse tree
	 */
	void enterType(MygrammerParser.TypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link MygrammerParser#type}.
	 * @param ctx the parse tree
	 */
	void exitType(MygrammerParser.TypeContext ctx);
}