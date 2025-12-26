internal class Program
{
	private static void Main(string[] args)
	{

		int[][] studentsMarks = new int[][]
		{
			[85, 90, 95], // Marks for Student 1
			[83, 92, 91, 88], // Marks for Student 2
			[85, 90] // Marks for Student 3
	};

		for (int i = 0; i < studentsMarks.Length; i++)
		{
			Console.WriteLine($"student {i + 1} marks: {string.Join(",", studentsMarks[i])}");
		}

		Console.ReadKey();
	}
}