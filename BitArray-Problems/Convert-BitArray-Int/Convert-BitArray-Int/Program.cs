using System.Collections;

internal class Program
{
	private static int ConvertBiArrayToInt(BitArray bits)
	{
		int result = 0;

		for (int i = 0; i < bits.Length; i++)
		{
			if (bits[i])
			{
				result += 1 << i;
			}
		}


		return result;
	}
	private static void Main(string[] args)
	{
		BitArray bits = new BitArray(new bool[] { true, true, true, false, true, true, false, false });

		int number = ConvertBiArrayToInt(bits);


		Console.WriteLine("After converting bits into number:" + number);


		Console.ReadKey();
	}
}