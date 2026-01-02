using System.Collections;

internal class Program
{
	private static void Main(string[] args)
	{
		var lights = new BitArray(8, false);

		lights[1] = true;
		lights[2] = true;

		Console.WriteLine($"Light 2: {(lights[1] ? "On" : "Off")}");

		// Reset All 

		lights.SetAll(false);

		// Light 2 after reseting
		Console.WriteLine($"Light 2: {(lights[1] ? "On" : "Off")}");
		Console.ReadKey();
	}
}