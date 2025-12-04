internal class Program
{
	public static string RemoveInvalidParentheses(string s)
	{

		Stack<int> stack = new();
		HashSet<int> invalidIndices = new();

		for (int i = 0; i < s.Length; i++)
		{
			if (s[i] == '(') stack.Push(i);

			else if (s[i] == ')')
			{
				if (stack.Count == 0) invalidIndices.Add(i);
				else stack.Pop();

			}

		}

		while (stack.Count > 0)
		{
			invalidIndices.Add(stack.Pop());
		}


		string newString = "";
		for (int i = 0; i < s.Length; i++)
		{
			if (!invalidIndices.Contains(i))
			{
				newString += s[i];
			}
		}

		return newString;
	}


	private static void Main(string[] args)
	{
		string s = "((((((())";

		Console.WriteLine($"After remove invalid parentheses:{RemoveInvalidParentheses(s)}");
		Console.ReadKey();
	}

}