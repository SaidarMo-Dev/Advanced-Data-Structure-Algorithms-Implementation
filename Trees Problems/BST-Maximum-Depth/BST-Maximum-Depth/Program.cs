internal class Program
{

	public class Tree
	{
		public BinaryTreeNode Root { get; set; }

		public Tree()
		{
			Root = null!;

		}

		public void Print()
		{
			Print(Root, 0);
		}
		public void Print(BinaryTreeNode Node, int Space)
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

		public void Insert(int value)
		{
			Root = Insert(Root, value);
		}
		private BinaryTreeNode Insert(BinaryTreeNode node, int value)
		{
			if (node == null)
			{
				return new BinaryTreeNode(value);

			}

			if (node.Value < value)
				node.Right = Insert(node.Right, value);
			if (node.Value > value)
				node.Left = Insert(node.Left, value);

			return node;
		}

		public int MaxDepth()
		{
			return MaxDepth(Root);
		}

		// Recursive helper to calculate max Deth
		private int MaxDepth(BinaryTreeNode node)
		{
			if (node == null) return 0;

			int leftDepth = MaxDepth(node.Left);
			int rightDepth = MaxDepth(node.Right);

			return Math.Max(rightDepth, leftDepth) + 1;
		}


	}

	private static void Main(string[] args)
	{

		var tree = new Tree();


		tree.Insert(101);
		tree.Insert(102);
		tree.Insert(100);

		tree.Print();

		// Calculate max depth
		Console.WriteLine("Maximum Depth :" + tree.MaxDepth());
		Console.ReadKey();
	}

	public class BinaryTreeNode
	{
		public int Value { get; set; }
		public BinaryTreeNode Right { get; set; }
		public BinaryTreeNode Left { get; set; }
		public int Height { get; set; }

		public BinaryTreeNode(int value)
		{
			Value = value;
			Right = null!;
			Left = null!;

		}
	}


}