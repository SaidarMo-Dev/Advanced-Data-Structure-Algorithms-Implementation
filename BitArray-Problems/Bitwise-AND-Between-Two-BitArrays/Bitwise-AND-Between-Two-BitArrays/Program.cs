using System.Collections;

internal class Program
{
	private static void Main(string[] args)
	{
		BitArray a = new BitArray(new bool[] { true, false, false, true, true, true });
		BitArray b = new BitArray(new bool[] { false, false, true, true, false, false });


		var result = BitwiseAnd(a, b);


		Console.WriteLine("Bitwise AND result: ");
		for (int i = 0; i < result.Length; i++)
		{
			Console.Write(result[i] + " ");
		}


		Console.ReadKey();
	}

	public static BitArray BitwiseAnd(BitArray a, BitArray b)
	{
		if (a.Length != b.Length)
			throw new ArgumentException("BitArrays must have the same length!");



		BitArray result = new BitArray(a.Length);

		for (int i = 0; i < a.Length; i++)
		{
			result[i] = a[i] & b[i];
		}

		// You  can also use the built-in method:  a.And(b);


		return result;
	}
}