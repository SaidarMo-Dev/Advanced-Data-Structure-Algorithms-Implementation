internal class Program
{
	public static bool IsParenstesisValide(string s)
	{
		Stack<char> stack = new();
		Dictionary<char, char> parentesis = new Dictionary<char, char>
		{
			{ ')', '(' },
			{ '}', '{' },
			{ ']', '[' },
		};


		foreach (char c in s)
		{
			if (parentesis.ContainsValue(c))
				stack.Push(c);

			else if (parentesis.ContainsKey(c))
			{
				if (stack.Count == 0 || stack.Pop() != parentesis[c])
					return false;
			}
		}

		return true;
	}


	private static void Main(string[] args)
	{
		string parentess = "(){}";

		Console.WriteLine(IsParenstesisValide(parentess));

		Console.ReadKey();
	}
}