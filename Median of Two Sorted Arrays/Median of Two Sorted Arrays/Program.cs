internal class Program
{

	public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
	{
		// merge arrays 
		var arr = nums1.Concat(nums2).ToList();

		arr.Sort();

		int m = nums1.Length;
		int n = nums2.Length;

		int length = n + m;

		if (length % 2 != 0) return arr[length / 2];

		int middle = length / 2;

		return ((double)(arr[middle - 1] + arr[middle])) / 2;

	}
	private static void Main(string[] args)
	{
		Console.WriteLine(FindMedianSortedArrays([2, 4,], [1, 5]));
	}
}