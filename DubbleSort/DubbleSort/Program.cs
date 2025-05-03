internal class Program
{
	private static void Main(string[] args)
	{
		var arrInt = new[] { 1,23, 21, 34,5, 80, 65, 3 };


		Console.WriteLine("Array Before sorting :");
		for (int i = 0; i < arrInt.Length; i++)
		{
			Console.Write(arrInt[i] + " ");
		}

		DubbleSort(arrInt);

		Console.WriteLine( "\nArray after sorting :");
		for (int i = 0; i < arrInt.Length; i++)
		{
			Console.Write(arrInt[i] + " ");
		}

		Console.ReadKey();
	}

	public static void DubbleSort(int[] arr)
	{
		for (int i = 0; i < arr.Length; i++)
		{
			for (int j = 0; j < arr.Length - i; j++)
			{
			
				if (!(j == arr.Length - 1) && arr[j] > arr[j+1])
				{

					(arr[j], arr[j+1]) = (arr[j+1], arr[j]);
				
				}
			}
		}
	}


}