using System.Collections;

internal class Program
{

	private static void Main(string[] args)
	{
		Hashtable ht1 = new Hashtable
		{
			{"Name", "Ali" },
			{"Age", 23 },
		};

		Hashtable ht2 = new Hashtable(ht1);


		Console.WriteLine("Contents of copied hashtable:");
		foreach (DictionaryEntry entry in ht2)
		{
			Console.WriteLine($"{entry.Key} : {entry.Value}");

		}


		Console.ReadKey();

	}
}