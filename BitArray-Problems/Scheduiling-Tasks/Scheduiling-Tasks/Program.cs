
using System.Collections;

internal class Program
{
	private static void Main(string[] args)
	{
		BitArray schelue = new BitArray(7, true);

		schelue[3] = false;
		schelue[5] = false;

		Console.Write("Free Days:");
		for (int i = 0; i < 7; i++)
		{
			if (!schelue[i]) Console.Write($" Day {i + 1}");


		}


		Console.ReadKey();
	}
}