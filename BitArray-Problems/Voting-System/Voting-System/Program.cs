using System.Collections;

internal class Program
{
	private static void Main(string[] args)
	{
		BitArray vootings = new BitArray(new bool[] { true, false, true, true, false, false, true, false });

		var yesVotes = 0;

		foreach (bool vote in vootings)
		{
			if (vote)
			{
				yesVotes++;
			}
		}

		Console.WriteLine($"Total Yes Votes: {yesVotes}");

		Console.ReadKey();
	}
}