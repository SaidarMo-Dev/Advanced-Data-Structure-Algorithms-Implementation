internal class Program
{
	public static int FindMajorityElement(int[] elements)
	{
		Dictionary<int, int> ElementsFrequencies = new Dictionary<int, int>();

		int majCount = elements.Length / 2;

		foreach (int element in elements)
		{
			if (!ElementsFrequencies.ContainsKey(element)) ElementsFrequencies[element] = 0;

			ElementsFrequencies[element]++;

			if (ElementsFrequencies[element] > majCount) return element;
		}

		return -1;
	}

	private static void Main(string[] args)
	{
		int[] elements = { 2, 3, 4, 3, 3 };


		Console.WriteLine($"Majority Element is:{FindMajorityElement(elements)}");

		Console.ReadKey();
	}
}