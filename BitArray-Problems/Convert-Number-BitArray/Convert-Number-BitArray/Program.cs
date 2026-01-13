using System.Collections;

internal class Program
{
	private static BitArray ConvertNumberToBitArray(int number)
	{

		return new BitArray(new[] { number });

	}
	private static void Main(string[] args)
	{
		int number = 12;
		var bits = ConvertNumberToBitArray(number);

		bool leadingZero = true;

		for (int i = bits.Length - 1; i >= 0; i--)
		{
			if (bits[i]) leadingZero = false;

			if (!leadingZero)
				Console.Write(bits[i] ? "1" : "0");
		}

		Console.ReadKey();
	}
}