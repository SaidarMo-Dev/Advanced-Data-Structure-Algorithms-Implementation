internal class Program
{
	public static int[] UniqueElements(int[] nums)
	{
		Dictionary<int, int> counts = new Dictionary<int, int>();

		foreach (int num in nums)
		{
			if (!counts.ContainsKey(num)) counts[num] = 0;

			counts[num]++;
		}

		List<int> unique = new();

		foreach (var kvp in counts)
		{
			if (kvp.Value == 1) unique.Add(kvp.Key);
		}

		return unique.ToArray();
	}


	private static void Main(string[] args)
	{
		int[] nums = { 1, 1, 2, 3 };

		Console.WriteLine($"Unique Elements: [{string.Join(",", UniqueElements(nums))}]");

		Console.ReadKey();
	}
}