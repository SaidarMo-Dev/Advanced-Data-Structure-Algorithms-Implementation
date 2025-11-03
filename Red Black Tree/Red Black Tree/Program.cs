internal class Program
{

	public class RedBlackTree
	{
		private Node root;


		// Node definition for the Red-Black Tree
		public class Node
		{


			public int Value;
			public Node Left, Right, Parent;
			public byte IsRed = 0; // New nodes are red by default

			public Node(int value)
			{
				Value = value;
			}
		}



	}
	private static void Main(string[] args)
	{

	}
}