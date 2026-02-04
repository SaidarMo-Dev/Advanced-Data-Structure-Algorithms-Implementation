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

		// Method to print the largest value in each level
		public void MaxValuePerTreeLevel()
		{
			MaxValuePerTreeLevel(Root);
		}
		// helper method to determine the largest value in each level
		private void MaxValuePerTreeLevel(BinaryTreeNode node, int level = 1)
		{
			if (node == null) return;

			if (node == Root)
				Console.WriteLine("Level 1:" + node.Value);


		}

	}

	private static void Main(string[] args)
	{

		var tree1 = new Tree();
		var tree2 = new Tree();


		tree1.Insert(101);
		tree1.Insert(102);
		tree1.Insert(100);

		tree2.Insert(101);
		tree2.Insert(102);
		tree2.Insert(100);

		Console.WriteLine("Tree 1");
		Console.WriteLine("==============================================================");
		tree1.Print();

		Console.WriteLine("Tree 2");
		Console.WriteLine("==============================================================");

		tree2.Print();

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