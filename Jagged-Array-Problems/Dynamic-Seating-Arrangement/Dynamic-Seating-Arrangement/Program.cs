internal class Program
{
	private static void Main(string[] args)
	{

		int[][] classroomSeats = new int[3][];
		classroomSeats[0] = [1, 2, 3]; // Row 1
		classroomSeats[1] = [4, 5, 8];    // Row 2
		classroomSeats[2] = [6, 7, 8, 9]; // Row 3


		Console.WriteLine("Classroom Seating:");
		for (int i = 0; i < classroomSeats.Length; i++)
		{
			Console.Write($"Row {i + 1}: ");
			foreach (int seat in classroomSeats[i])
			{
				Console.Write(seat + " ");
			}
			Console.WriteLine();
		}
		Console.ReadKey();
	}
}