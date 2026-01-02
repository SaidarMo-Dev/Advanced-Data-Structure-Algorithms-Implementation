internal class Program
{
	public static (bool Success, int Value) CheckMark(int Mark)
	{
		if (Mark >= 50) return (true, Mark);

		return (false, Mark);
	}

	private static void Main(string[] args)
	{
		var result = CheckMark(99);

		Console.WriteLine($"Success:{result.Success}, Value:{result.Value}");
		Console.ReadKey();
	}
}