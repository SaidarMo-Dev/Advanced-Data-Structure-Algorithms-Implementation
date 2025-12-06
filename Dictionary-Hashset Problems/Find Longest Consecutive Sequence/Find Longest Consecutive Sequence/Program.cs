internal class Program
{
	public static int FindLongestConsecutiveSequence(int[] numbres)
	{
		HashSet<int> set = new HashSet<int>(numbres);

		int maxLength = 0;

		foreach (int n in set)
		{
			if (!set.Contains(n - 1))
			{
				var currentNum = n;
				var currentSequence = new List<int> { n };

				while (set.Contains(currentNum + 1))
				{
					currentNum++;
					currentSequence.Add(currentNum);
				}

				maxLength = Math.Max(maxLength, currentSequence.Count);

			}
		}

		return maxLength;
	}
	private static void Main(string[] args)
	{
		int[] numbers = { 200, 4, 100, 1, 2 };

		var result = FindLongestConsecutiveSequence(numbers);

		Console.WriteLine($"Max length:{result}");


		Console.ReadKey();
	}
}