using System.Diagnostics;
using System.Runtime.CompilerServices;

internal class Program
{
	private static void Main(string[] args)
	{

		Stopwatch sw = new Stopwatch();

		int[] arr = [9, 3, 7, 2, 1, 8];

		Console.WriteLine("\nBefore Sorting :");
		for (int i = 0; i < arr.Length; i++)
			Console.WriteLine(arr[i]);

		sw.Start();
		InsertionSortASCMethod2(arr);
		sw.Stop();

		Console.WriteLine("time consuming :" + sw.Elapsed.TotalMilliseconds);

		Console.WriteLine("\nAfter Sorting:");
		for (int i = 0; i < arr.Length; i++)
			Console.WriteLine(arr[i]);
		Console.ReadKey();
	}

	public static void InsertionSortASC(int[] Arr)
	{

		for (int i = 1; i < Arr.Length; i++)
		{
			int keyIndex = i;

			for (int j = i - 1; j >= 0; j--)
			{

				if (Arr[keyIndex] < Arr[j])
				{

					(Arr[j], Arr[keyIndex]) = (Arr[keyIndex], Arr[j]);
					keyIndex = j;

				}
				else
					break;
			}


		}
	}
	public static void InsertionSortDESC(int[] Arr)
	{

		for (int i = 1; i < Arr.Length; i++)
		{
			int key = i;

			for (int j = i - 1; j >= 0; j--)
			{

				if (Arr[key] > Arr[j])
				{
					
					(Arr[j], Arr[key]) = (Arr[key], Arr[j]);
					key = j;

				}
				else
					break;
			}


		}

	}

	public static void InsertionSortASCMethod2(int[] arr)
	{
		for (int i = 1; i < arr.Length; i++)
		{
			int key = arr[i];
			int j = i-1;

			while(j >= 0 && arr[j] > key)
			{
				arr[j+1 ] = arr[j];

				j--;

			}

			arr[j + 1] = key;
		}
	}
}