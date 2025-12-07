internal class Program
{
	public static int[] DuplicateElements(int[] nums)
	{
		Dictionary<int, int> counts = new Dictionary<int, int>();
		List<int> duplicate = new List<int>();

		foreach (int num in nums)
		{
			if (counts.ContainsKey(num))
			{
				counts[num]++;

				if (counts[num] == 2) duplicate.Add(num);
			}
			else
				counts[num] = 1;

		}

		return duplicate.ToArray();
	}
	private static void Main(string[] args)
	{
		int[] nums = { 1, 2, 2, 3, 3, 4 };


		Console.WriteLine($"Duplicate ELements: {string.Join(",", DuplicateElements(nums))}");
		Console.ReadKey();
	}
}