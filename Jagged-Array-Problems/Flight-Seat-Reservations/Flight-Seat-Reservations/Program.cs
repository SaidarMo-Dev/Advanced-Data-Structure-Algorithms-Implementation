internal class Program
{
	private static void Main(string[] args)
	{
		bool[][] flightSeats = new bool[4][];

		flightSeats[0] = [false, true, true]; // Seat 1
		flightSeats[1] = [true, true, false, false, true];// Seat 2
		flightSeats[2] = [false, true];// Seat 3
		flightSeats[3] = [false];// Seat 4


		for (int i = 0; i < flightSeats.Length; i++)
		{
			Console.Write("\nSeat " + (i + 1) + ":");
			foreach (bool seat in flightSeats[i])
			{
				Console.Write(seat ? "Reserved " : "Available ");
			}
		}
		Console.ReadKey();
	}
}