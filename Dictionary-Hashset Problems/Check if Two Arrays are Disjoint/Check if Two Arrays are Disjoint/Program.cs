internal class Program
{
	public static bool DisjointArrays(int[] arr1, int[] arr2)
	{

		// Using Hashset for quick loockups
		HashSet<int> set2 = [.. arr2];


		foreach (int num in arr1)
		{
			if (set2.Contains(num)) return false;
		}

		return true;
	}

	private static void Main(string[] args)
	{
		int[] arr1 = { 1, 2, 3 }, arr2 = { 4, 5, 6 };

		Console.WriteLine(DisjointArrays(arr1, arr2));

		Console.ReadKey();
	}
}