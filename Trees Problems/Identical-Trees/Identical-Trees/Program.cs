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

		// Method to determine if two trees are identical
		public bool IsIdentical(BinaryTreeNode root1, BinaryTreeNode root2)
		{
			// Base case: both nodes are null
			if (root1 == null && root2 == null)
				return true;

			// If one is null and the other is not, they are not identical
			if (root1 == null || root2 == null)
				return false;


			if (root1.Value != root2.Value) return false;

			// Check if the current nodes are identical and recursively check subtrees
			return IsIdentical(root1.Left, root2.Left)
				&&
				IsIdentical(root1.Right, root2.Right);

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

		// Check if the two trees are identical
		Console.WriteLine("Are tree1 and tree2 Identical? " + tree1.IsIdentical(tree1.Root, tree2.Root));

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