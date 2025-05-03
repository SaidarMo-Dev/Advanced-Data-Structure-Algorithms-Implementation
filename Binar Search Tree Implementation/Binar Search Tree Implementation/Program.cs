internal class Program
{

	public class Tree<T>
	{
		public BinaryTreeNode<T> Root { get; set; }

		public Tree()
		{
			Root = null!;

		}

		public void Print()
		{
			Print(Root, 0);
		}
		public void Print(BinaryTreeNode<T> Node, int Space)
		{
			int count = 10;
			if (Node == null)
				return;

			Space += count;


			Print(Node.Right, Space);


			for (int i = count; i < Space; i++)
				Console.Write(" ");

			Console.WriteLine(Node.Value);


			Print(Node.Left, Space);



		}

		// Insert method
		/*
		 This method Insert Values in the three
		 And it Make Sure to insert Values In this Order : 
		
		- Left Subtree contains nodes with values less than the current node.

		- Right Subtree contains nodes with values greater than the current node.
		
		 */
		public void Insert(T value)
		{
			if (Root == null)
			{
				Root = new BinaryTreeNode<T>(value);
				return;
			}

			var newNode = new BinaryTreeNode<T>(value);

			Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();

			queue.Enqueue(Root);
			while (queue.Count > 0)
			{
				var current = queue.Dequeue();

				if (current.Left == null)
				{
					current.Left = newNode;
					break;
				}
				else
					queue.Enqueue(current.Left);

				if (current.Right == null)
				{
					current.Right = newNode;
					break;
				}
				else
					queue.Enqueue(current.Right);


			}

		}


		// PreOrder traversal (Root → Left → Right)
		public void PreOrderTraversal()
		{
			PreOrderTraversal(Root);
		}
		public void PreOrderTraversal(BinaryTreeNode<T> Root)
		{
			if (Root == null)
				return;

			Console.WriteLine($"{Root.Value} ");

			PreOrderTraversal(Root.Left);

			PreOrderTraversal(Root.Right);

		}

		// PostOrder traversal (Left → Right → Root )

		public void PostOrderTraversal()
		{
			PostOrderTraversal(Root);
		}
		public void PostOrderTraversal(BinaryTreeNode<T> Root)
		{

			if (Root == null)
				return;

			PostOrderTraversal(Root.Left);

			PostOrderTraversal(Root.Right);

			Console.WriteLine($"{Root.Value}");

		}

		// InOrder Traversal (Left → Root → Right)

		public void InOrderTraversal()
		{
			InOrderTraversal(Root);

		}
		public void InOrderTraversal(BinaryTreeNode<T> Root)
		{
			if (Root == null) return;

			InOrderTraversal(Root.Left);

			Console.WriteLine($"{Root.Value}");

			InOrderTraversal(Root.Right);
		}

		// Level-Order traversal

		public void LevelOrder()
		{
			LevelOrder(Root);
		}
		public void LevelOrder(BinaryTreeNode<T> Root)
		{

			if (Root == null) return;

			var queue = new Queue<BinaryTreeNode<T>>();

			queue.Enqueue(Root);

			while (queue.Count > 0)
			{

				var current = queue.Dequeue();

				Console.Write(current.Value + " ");

				if (current.Left != null)
				{
					queue.Enqueue(current.Left);
				}

				if (current.Right != null)
				{
					queue.Enqueue(current.Right);
				}


			}
		}

	}

	private static void Main(string[] args)
	{

		var tree = new Tree<int>();

		for (int i = 1; i <= 20; i++)
			tree.Insert(i);

		tree.Print();

		//tree.PreOrderTraversal();
		//tree.PostOrderTraversal();
		//tree.InOrderTraversal();

		tree.LevelOrder();



		Console.ReadKey();
	}

	public class BinaryTreeNode<T>
	{
		public T Value { get; set; }
		public BinaryTreeNode<T> Right { get; set; }
		public BinaryTreeNode<T> Left { get; set; }

		public BinaryTreeNode(T value)
		{
			Value = value;
			Right = null!;
			Left = null!;

		}
	}


}