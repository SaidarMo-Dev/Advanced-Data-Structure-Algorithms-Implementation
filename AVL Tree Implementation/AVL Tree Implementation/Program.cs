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

		UpdateHeight(node);
		return Balance(node);
	}

	private void UpdateHeight(AVLNode node)
	{
		//this will add 1 to the max height and update the node height.
		node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
	}

	private int Height(AVLNode node)
	{
		return node != null ? node.Height : 0;
	}

	private int GetBalanceFactor(AVLNode node)
	{
		return (node != null) ? Height(node.Left) - Height(node.Right) : 0;
	}

	private AVLNode Balance(AVLNode node)
	{

		//this function will balance the node.

		int balanceFactor = GetBalanceFactor(node);

		//decide which rotation to use and work accordengly.

		// RR - Right Rotation Case : Parent BF=-2 , Child BF for right child = -1 or 0
		if (balanceFactor < -1 && GetBalanceFactor(node.Right) <= 0)
			return LeftRotate(node);

		// LL Case: Parent BF=+2 , Child BF for left child = +1 or 0
		if (balanceFactor > 1 && GetBalanceFactor(node.Left) >= 0)
			return RightRotate(node);


		// LR - Left Rotation Case : Parent BF=+2 , Child BF for right child = -1 
		if (balanceFactor > 1 && GetBalanceFactor(node.Left) < 0)
		{
			//Step1: Perform left rotation
			node.Left = LeftRotate(node.Left);
			//Step2: Perfrom Rigth Rotation
			return RightRotate(node);
		}

		// RL - Right-Left Rotation Case : Parent BF=-2 , Child BF for right child = +1
		if (balanceFactor < -1 && GetBalanceFactor(node.Right) > 0)
		{
			// Step1: Perform right rotation
			node.Right = RightRotate(node.Right);
			// Step2: Perfrom Left Rotation
			return LeftRotate(node);
		}

		return node;
	}

	private AVLNode RightRotate(AVLNode OriginalRoot)
	{


		// The left child of the node becomes the new root of the subtree.
		AVLNode NewRoot = OriginalRoot.Left;

		//Save the Original Rigth Child Temperorly
		AVLNode OriginalRightChild = NewRoot.Right;


		//The original root node becomes the right child of the new root.
		NewRoot.Right = OriginalRoot;

		// The original root node becomes the right child of the new root.
		OriginalRoot.Left = OriginalRightChild;

		UpdateHeight(OriginalRoot);
		UpdateHeight(NewRoot);

		//Finally, the node NewRoot, which is now the root of this subtree after the rotation, is returned.
		return NewRoot;
	}

	private AVLNode LeftRotate(AVLNode OriginalRoot)
	{


		//Right child of the node becomes the new root of the subtree
		AVLNode NewRoot = OriginalRoot.Right;
		//Save the Original Left Child Temperorly
		AVLNode OriginalLeftChild = NewRoot.Left;

		//Original root node becomes the left child of the new root.
		NewRoot.Left = OriginalRoot;

		//The new root  left child,it becomes the right child of the new right child(the original root)
		OriginalRoot.Right = OriginalLeftChild;

		UpdateHeight(OriginalRoot);
		UpdateHeight(NewRoot);

		//Finally, the node NewRoot, which is now the root of this subtree after the rotation, is returned.
		return NewRoot;
	}

	public void Delete(int value)
	{
		root = DeleteNode(root, value);
	}

	private AVLNode DeleteNode(AVLNode node, int value)
	{
		if (node == null)
		{
			return node;
		}

		// Step 1: Perform standard BST delete
		if (value < node.Value)
		{
			node.Left = DeleteNode(node.Left, value);
		}
		else if (value > node.Value)
		{
			node.Right = DeleteNode(node.Right, value);
		}
		else
		{
			//If the node to be deleted has one child or no child,
			//simply remove the node and return the non - null child.

			// Node with only one child or no child
			if (node.Left == null)
			{
				return node.Right;
			}
			else if (node.Right == null)
			{
				return node.Left;
			}

			//if the node to be deleted has two children,
			//find the smallest node in the right subtree (inorder successor), then
			//copy its value to the node to be deleted, and then recursively delete the inorder successor.

			// Node with two children: Get the inorder successor (smallest in the right subtree)
			AVLNode temp = MinValueNode(node.Right);

			// Copy the inorder successor's data to this node
			node.Value = temp.Value;

			// Delete the inorder successor
			node.Right = DeleteNode(node.Right, temp.Value);
		}

		// Step 2: Update height of the current node
		UpdateHeight(node);

		// Step 3: Rebalance the node if needed
		return Balance(node);
	}

	private AVLNode MinValueNode(AVLNode node)
	{
		/* the minimum value is always located in the leftmost node.
		 This is because for any given node in a BST,
		  all values in the left subtree are less than the value of the node,
		  and all values in the right subtree are greater.*/

		AVLNode current = node;
		while (current.Left != null)
		{
			current = current.Left;
		}
		return current;
	}


	public AVLNode Find(int value)
	{
		return FindNode(root, value);
	}
	private AVLNode FindNode(AVLNode node, int value)
	{

		if (node == null)
			return node;

		if (node.Value == value) return node;

		if (value < node.Value)
		{
			return FindNode(node.Left, value);
		}
		else if (value > node.Value) return FindNode(node.Right, value);

		return null;
	}


	public bool IsExist(int value)
	{
		return IsExist(root, value);
	}
	private bool IsExist(AVLNode node, int value)
	{

		if (node == null)
			return false;

		if (node.Value == value) return true;

		if (value < node.Value)
		{
			return IsExist(node.Left, value);
		}
		else if (value > node.Value) return IsExist(node.Right, value);

		return false;

	}
}

class Program
{
	static void Main(string[] args)
	{

	}
}
