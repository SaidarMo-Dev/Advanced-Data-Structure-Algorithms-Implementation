internal class Program
{

	class Graph
	{
		public enum enGraphDirectionType { Directed, unDirected }

		private int[,] _adjacencyMatrix; // Adjacency matrix to represent the graph
		private Dictionary<string, int> _vertexDictionary; // Maps vertex names to matrix indices
		private int _numberOfVertices; // Number of vertices in the graph
		private enGraphDirectionType _GraphDirectionType = enGraphDirectionType.unDirected;

		// Constructor to initialize the graph
		public Graph(List<string> vertices, enGraphDirectionType GraphDirectionType)
		{
			_GraphDirectionType = GraphDirectionType;
			_numberOfVertices = vertices.Count; // Total number of vertices
			_adjacencyMatrix = new int[_numberOfVertices, _numberOfVertices]; // Initialize adjacency matrix
			_vertexDictionary = new Dictionary<string, int>(); // Initialize vertex dictionary

			// Map vertex names to indices
			for (int i = 0; i < vertices.Count; i++)
			{
				_vertexDictionary[vertices[i]] = i;
			}
		}

		// Add a weighted edge between two vertices
		public void AddEdge(string source, string destination, int weight)
		{
			if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
			{
				int sourceIndex = _vertexDictionary[source];
				int destinationIndex = _vertexDictionary[destination];
				_adjacencyMatrix[sourceIndex, destinationIndex] = weight;

				// Add the reverse edge for undirected graphs
				if (_GraphDirectionType == enGraphDirectionType.unDirected)
				{
					_adjacencyMatrix[destinationIndex, sourceIndex] = weight;
				}
			}
			else
			{
				Console.WriteLine($"Invalid vertices: {source} or {destination}");
			}
		}

		// Method to display the graph 
		public void DisplayGraph(string message)
		{
			Console.WriteLine("\n" + message + "\n");
			Console.Write("  ");
			foreach (var vertex in _vertexDictionary.Keys)
			{
				Console.Write(vertex + " ");
			}
			Console.WriteLine();

			foreach (var source in _vertexDictionary)
			{
				Console.Write(source.Key + " ");
				for (int j = 0; j < _numberOfVertices; j++)
				{
					Console.Write(_adjacencyMatrix[source.Value, j] + " ");
				}
				Console.WriteLine();
			}
		}

		// Perform Breadth-First Search (BFS)
		public void BFS(string startVertex)
		{
			if (!_vertexDictionary.ContainsKey(startVertex))
			{
				Console.WriteLine("Invalid start vertex.");
				return;
			}

			bool[] visited = new bool[_numberOfVertices]; // Keep track of visited vertices

			Queue<int> queue = new Queue<int>(); // Queue for BFS

			int startIndex = _vertexDictionary[startVertex];

			visited[startIndex] = true; // Mark start vertex as visited
			queue.Enqueue(startIndex);

			Console.WriteLine("\nBreadth-First Search:");

			while (queue.Count > 0)
			{
				int currentVertex = queue.Dequeue();
				Console.Write($"{GetVertexName(currentVertex)} "); // Print the current vertex

				// Add all unvisited neighbors to the queue
				for (int i = 0; i < _numberOfVertices; i++)
				{
					if (_adjacencyMatrix[currentVertex, i] > 0 && !visited[i])
					{
						visited[i] = true;
						queue.Enqueue(i);
					}
				}
			}

			Console.WriteLine();
		}

		// Helper method to get vertex name by index
		private string GetVertexName(int index)
		{
			foreach (var pair in _vertexDictionary)
			{
				if (pair.Value == index)
					return pair.Key;
			}
			return "Unknown";
		}




	}
	private static void Main(string[] args)
	{
		var graph = new Graph(new List<string> { "a", "b", "c", "d", "e" }, Graph.enGraphDirectionType.Directed);
		// Add edges
		graph.AddEdge("a", "b", 1);
		graph.AddEdge("a", "c", 1);

		graph.AddEdge("b", "c", 1);
		graph.AddEdge("b", "d", 1);

		graph.AddEdge("c", "d", 1);
		graph.AddEdge("c", "e", 1);


		graph.DisplayGraph("Adjacency Matrix (Directed Graph):");
		graph.BFS("b");

		Console.ReadKey();
	}
}