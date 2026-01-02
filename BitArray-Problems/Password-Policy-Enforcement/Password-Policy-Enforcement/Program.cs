using System.Collections;

internal class Program
{
	private static void Main(string[] args)
	{
		BitArray passwordPolicy = new BitArray(4);

		string password = "Test231!";

		passwordPolicy.Set(0, password.Any(char.IsUpper));
		passwordPolicy.Set(1, password.Any(char.IsLower));
		passwordPolicy.Set(2, password.Any(char.IsDigit));
		passwordPolicy.Set(3, password.Any(c => "!@#$%&*^".Contains(c)));


		bool IsValid = passwordPolicy.Cast<bool>().All(bit => bit);

		Console.WriteLine($"Password Valid: {IsValid}");

		Console.ReadKey();
	}
}