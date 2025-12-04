using System.Text.RegularExpressions;

internal class Program
{
	class Tokenizer
	{
		public static string[] Tokenize(string input)
		{
			string pattern = @"\d+\.\d+|\d+|\+|-|\*|/|\(|\)";
			MatchCollection matches = Regex.Matches(input, pattern);

			string[] tokens = new string[matches.Count];

			for (int i = 0; i < matches.Count; i++)
			{
				tokens[i] = matches[i].Value;
			}

			return tokens;
		}
	}

	class SimpleCalculator
	{

		public string Operation { get; set; }
		public SimpleCalculator(string operation)
		{
			Operation = operation;
		}


		Dictionary<string, int> _percendence = new Dictionary<string, int>
		{
			{"+" , 1 },
			{"-" , 1 },
			{"*" , 2 },
			{"/" , 2 },
			{"(" , 0 },
			{")" , 0 },
		};

		string[] _exprs = ["+", "-", "*", "/"];

		public int Calculate()
		{
			// Tokenize the operation into numbers and operators
			string[] tokens = Tokenizer.Tokenize(Operation);

			// A stack to store numbers (operands)
			Stack<int> operands = new Stack<int>();

			// A stack to store operators
			Stack<string> operators = new Stack<string>();

			// Iterate through the tokens
			foreach (string token in tokens)
			{
				// if the token is a number, push it onto the operands stack
				if (token.All(char.IsDigit)) operands.Push(Convert.ToInt32(token));


				else if (_exprs.Contains(token))
				{
					// If the token is an operator :
					// Iterate while the operators stack is not empty and the top operator has higher ir equal percendence
					// Pop the top operator and apply it to the top two operands

					while (operators.Count != 0 && _percendence[operators.Peek()] >= _percendence[token])
					{
						var topOpereator = operators.Pop();

						int b = operands.Pop();
						int a = operands.Pop();

						operands.Push(ApplyOperation(a, b, topOpereator));
					}

					// Push the current operaotor
					operators.Push(token);
				}
				// push the token if it is a left parenthesis
				else if (token == "(")
				{
					operators.Push(token);
				}
				// if the token is a right parenthesis
				// While the top operators stack is not a left parenthesis,
				// pop the top operator and apply it to the top two operands

				else if (token == ")")
				{
					while (operators.Peek() != "(")
					{

						int b = operands.Pop();
						int a = operands.Pop();

						operands.Push(ApplyOperation(a, b, operators.Pop()));
					}

					// Pop the left parenthesis
					operators.Pop();
				}
			}



			// Pop the top operator and apply it to the top two operands
			// until the operators stack is empty

			while (operators.Count != 0)
			{
				int b = operands.Pop();
				int a = operands.Pop();

				operands.Push(ApplyOperation(a, b, operators.Pop()));
			}

			// the final result is the only element left in the operands stack
			return operands.Pop();
		}

		private static int ApplyOperation(int a, int b, string op)
		{
			switch (op)
			{
				case "+": return a + b;
				case "-": return a - b;
				case "*": return a * b;
				case "/": return a / b;
				default:
					return 0;
			}
		}
	}
	private static void Main(string[] args)
	{

		SimpleCalculator simpleCalculator = new SimpleCalculator("2*2*(12-2)");


		Console.WriteLine($"The result of {simpleCalculator.Operation} is : {simpleCalculator.Calculate()}");
		Console.ReadKey();
	}


}