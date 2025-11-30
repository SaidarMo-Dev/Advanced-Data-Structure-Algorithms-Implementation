internal class Program
{
	private static void Main(string[] args)
	{
		Console.WriteLine("Enter n numbers to convert to Binary:");
		string? n = Console.ReadLine();

		Console.WriteLine("Numbers Converted are:");
		var numbersToBinray = GenerateBinaryNumbers(Convert.ToInt32(n));
		foreach (var number in numbersToBinray)
		{
			Console.WriteLine(number);
		}
		Console.ReadKey();
	}

	public static string[] GenerateBinaryNumbers(int n)
	{
		string[] numbers = new string[n];

		for (int i = 0; i < n; i++)
		{
			int number = i + 1;

			Queue<int> queue = new Queue<int>();
			while (number > 0)
			{
				queue.Enqueue(number % 2);
				number /= 2;
			}

			numbers[i] = string.Join("", queue.ToArray());
		}

		return numbers;
	}
}