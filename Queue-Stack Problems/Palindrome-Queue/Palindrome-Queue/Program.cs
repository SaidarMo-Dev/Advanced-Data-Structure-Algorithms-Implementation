internal class Program
{
	private static void Main(string[] args)
	{
		Queue<int> queue = new Queue<int>([1, 2, 3, 2, 1]);

		Console.WriteLine("Checking if the queue is Palindrome:");
		Console.WriteLine(IsPalindrome(queue) ? "the queue is Palindrome" : "the queue is not Palindrome");
	}

	public static bool IsPalindrome(Queue<int> queue)
	{
		Stack<int> stack = new(queue);

		while (stack.Count > 0)
		{
			if (queue.Dequeue() != stack.Pop()) return false;

		}

		return true;
	}
}