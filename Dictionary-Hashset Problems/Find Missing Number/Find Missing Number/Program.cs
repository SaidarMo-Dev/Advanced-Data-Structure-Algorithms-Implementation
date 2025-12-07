internal class Program
{
	public static int MissingNumber(int[] nums)
	{
		Dictionary<int, bool> counts = new Dictionary<int, bool>();

		foreach (int i in nums)
		{
			counts[i] = true;
		}

		for (int i = 0; i <= nums.Length; i++)
		{
			if (!counts.ContainsKey(i))
				return i;

		}

		return -1;
	}
	private static void Main(string[] args)
	{
		int[] numbers = { 0, 2, 3 };

		int missingN = MissingNumber(numbers);

		Console.WriteLine("Missing number is:" + (missingN != -1 ? missingN : "No Number Missing"));
		Console.ReadKey();
	}
}