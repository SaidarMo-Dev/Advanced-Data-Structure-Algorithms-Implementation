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
			// Standard Binary Search Tree insertion
			Node current = root;
			Node parent = null;
			while (current != null)
			{
				parent = current;
				if (newValue < current.Value)
					current = current.Left;
				else
					current = current.Right;
			}

			// Set the parent of the new node
			newNode.Parent = parent;
			if (newValue < parent.Value)
				parent.Left = newNode;
			else
				parent.Right = newNode;



		}
	}
	private static void Main(string[] args)
	{

	}
}