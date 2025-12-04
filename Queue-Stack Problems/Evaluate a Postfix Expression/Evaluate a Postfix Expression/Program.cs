internal class Program
{
	public static int EvaluatePostfixExpr(string input)
	{
		Stack<int> stack = new Stack<int>();

		foreach (char chr in input)
		{
			if (char.IsDigit(chr))
				stack.Push(chr - '0');

			else
			{
				int a = stack.Pop();
				int b = stack.Pop();

				switch (chr)
				{
					case '+':
						stack.Push(b + a);
						break;
					case '-':
						stack.Push(b - a);
						break;
					case '*':
						stack.Push(b * a);
						break;
					case '/':
						stack.Push(b / a);
						break;
				}
			}
		}
		return stack.Pop();

	}

	private static void Main(string[] args)
	{
		string s = "231*+9-";

		Console.WriteLine(EvaluatePostfixExpr(s));
		Console.ReadKey();
	}
}