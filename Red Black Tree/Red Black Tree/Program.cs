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
			public bool IsRed = true; // New nodes are red by default

			public Node(int value)
			{
				Value = value;
			}
		}

		// Public method to insert a value into the tree
		public void Insert(int newValue)
		{
			Node newNode = new Node(newValue);
			// handle the special case when the tree is empty

			if (root == null)
			{
				root = newNode;
				newNode.IsRed = false;
				return;
			}

			// Standar Binary Search Tree Insertion

			Node current = root;
			Node parent = null;

			while (current != null)
			{
				parent = current;
				if (current.Value < newValue)
					current = current.Left;
				else if (current.Value > newValue)
					current = current.Right;

			}

		}
	}
	private static void Main(string[] args)
	{

	}
}