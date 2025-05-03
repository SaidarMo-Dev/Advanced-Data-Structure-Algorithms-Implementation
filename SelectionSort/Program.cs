internal class Program
{
	private static void Main(string[] args)
	{

		var arr = new int[] { 21, 3, 45, 6, 78, 65, 102, 31 };


		Console.WriteLine("Before sorting: ");
		for (int i = 0; i < arr.Length; i++)
		{
			Console.Write(arr[i] + " ");

		}

		SelectionSortDESC(arr);

		Console.WriteLine("\nafter sorting: ");
		for (int i = 0; i < arr.Length; i++)
		{
			Console.Write(arr[i] + " ");

		}




		Console.ReadKey();

	}

	private static void SelectionSortASC(int[] arr)
	{
		int Length = arr.Length;
		int MinIndex = 0;


		for (int i = 0; i < Length; i++)
		{


			int MinValueIndex = MinIndex;

			if (i == Length - 1)
				return;

			for (int j = MinIndex; j < Length; j++)
			{
				if (arr[j] < arr[MinValueIndex])
				{
					MinValueIndex = j;
				}

			}

			(arr[MinIndex], arr[MinValueIndex]) = (arr[MinValueIndex], arr[MinIndex]);

			++MinIndex;

		}

	}
	private static void SelectionSortDESC(int[] arr)
	{
		int Length = arr.Length;
		int MinIndex = 0;


		for (int i = 0; i < Length; i++)
		{


			int MinValueIndex = MinIndex;

			if (i == Length - 1)
				return;

			for (int j = MinIndex; j < Length; j++)
			{
				if (arr[j] > arr[MinValueIndex])
				{
					MinValueIndex = j;
				}

			}

			(arr[MinIndex], arr[MinValueIndex]) = (arr[MinValueIndex], arr[MinIndex]);

			++MinIndex;

		}

	}


}