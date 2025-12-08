internal class Program
{
	public static List<int> ElementsNotInSocendArray(int[] arr1, int[] arr2)
	{
		HashSet<int> set = [.. arr2];

		List<int> result = new();

		foreach (int num in arr1)
		{
			if (!set.Contains(num)) result.Add(num);
		}

		return result;

	}
	private static void Main(string[] args)
	{
		int[] arr1 = { 1, 2, 3, 4, 5, 6 }, arr2 = { 3, 4, 5 };

		Console.WriteLine($"Elements that is not in the second array are: " +
			$"{string.Join(",", ElementsNotInSocendArray(arr1, arr2))}");



		Console.ReadKey();
	}
}