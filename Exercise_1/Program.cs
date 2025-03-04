class Program
{
    private static readonly char CURLY_OPENING_BRACKET = '{';
    private static readonly char SQUARE_OPENING_BRACKET = '[';
    private static readonly char ROUND_OPENING_BRACKET = '(';

    private static readonly char CURLY_CLOSING_BRACKET = '}';
    private static readonly char SQUARE_CLOSING_BRACKET = ']';
    private static readonly char ROUND_CLOSING_BRACKET = ')';

    private static void Main()
    {
        string[] exp = { "[()]{}{[()()]()}", "[(])"};

        for (int i = 0; i < exp.Length; i ++)
        {

            if (BalancedBrackets(exp[i]))
            {
                Console.WriteLine("Balanced");
            }
            else
            {
                Console.WriteLine("Not Balanced");
            }
        }
    }

    /// <summary>
    ///     Check whether the string contains balanced brackets
    /// </summary>
    /// <param name="exp">
    ///     The string to check
    /// </param>
    /// <returns>
    ///     True if the brackets are balanced, false otherwise
    /// </returns>
    private static bool BalancedBrackets(string exp)
    {
        if (string.IsNullOrEmpty(exp))
        {
            // Empty string
            return false;
        }

        Stack<char> stack = new();

        foreach (char symbol in exp)
        {
            if (IsOpening(symbol))
            {
                stack.Push(symbol);

            } 
            else if (IsClosing(symbol))
            {
                if (stack.Count == 0)
                {
                    // There is closing bracket, but no opening
                    return false;
                }

                var lastBracket = stack.Pop();

                if (!AreMatchingBrackets(lastBracket, symbol))
                {
                    // The last bracket in the stack and the current symbol
                    // are not matching brackets 
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }

    /// <summary>
    ///     Check whether the symbol is opening bracket
    /// </summary>
    /// <param name="symbol">
    ///     The symbol to check
    /// </param>
    /// <returns>
    ///     True if the symbol is opening bracket, false otherwise
    /// </returns>
    private static bool IsOpening(char symbol) {
        return symbol == CURLY_OPENING_BRACKET || symbol == SQUARE_OPENING_BRACKET || symbol == ROUND_OPENING_BRACKET;
    }

    /// <summary>
    ///     Check whether the symbol is closing bracket
    /// </summary>
    /// <param name="symbol">
    ///     The symbol to check
    /// </param>
    /// <returns>
    ///     True if the symbol is closing bracket, false otherwise
    /// </returns>
    private static bool IsClosing(char symbol)
    {
        return symbol == CURLY_CLOSING_BRACKET || symbol == SQUARE_CLOSING_BRACKET || symbol == ROUND_CLOSING_BRACKET;
    }

    /// <summary>
    ///     Check whether the symbols are matching brackets(same type) - e.g '{' and '}'
    /// </summary>
    /// <param name="first">
    ///     The first symbol 
    /// </param>
    /// <param name="second">
    ///     The second symbol 
    /// </param>
    /// <returns>
    ///     True if the symbols are matching brackets, false otherwise
    /// </returns>
    private static bool AreMatchingBrackets(char first, char second)
    {
        return (first == CURLY_OPENING_BRACKET && second == CURLY_CLOSING_BRACKET) ||
                (first == SQUARE_OPENING_BRACKET && second == SQUARE_CLOSING_BRACKET) ||
                (first == ROUND_OPENING_BRACKET && second == ROUND_CLOSING_BRACKET);

    }

}