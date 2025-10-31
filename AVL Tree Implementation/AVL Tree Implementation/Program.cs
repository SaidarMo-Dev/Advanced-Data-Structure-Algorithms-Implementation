class AVLNode
{
	public int Value { get; set; }
	public AVLNode Left { get; set; }
	public AVLNode Right { get; set; }
	public int Height { get; set; }

	public AVLNode(int value)
	{
		Value = value;
		Height = 1; // Initially, when a node is created, its height is set to 1.
	}
}

class AVLTree
{
	private AVLNode root;

	public void Insert(int value)
	{
		root = Insert(root, value);
	}

	private AVLNode Insert(AVLNode node, int value)
	{
		if (node == null)
			return new AVLNode(value);


		if (value < node.Value)
			node.Left = Insert(node.Left, value);
		else if (value > node.Value)
			node.Right = Insert(node.Right, value);
		else
			return node; // Duplicate values are not allowed

		return node;
	}

}

class Program
{
	static void Main(string[] args)
	{


	}
}
