internal class Program
{
	public static List<int> DisappearedNumbers(int[] nums)
	{
		HashSet<int> presentNums = new(nums);


		List<int> result = new();

		for (int i = 1; i <= nums.Length; i++)
		{
			if (!presentNums.Contains(i)) result.Add(i);
		}

		return result;
	}
	private static void Main(string[] args)
	{
		int[] nums = { 23, 22, 4, 5, 6 };
		Console.WriteLine($"Missing numbers are:{string.Join(",", DisappearedNumbers(nums))}");


		Console.ReadKey();
	}
}