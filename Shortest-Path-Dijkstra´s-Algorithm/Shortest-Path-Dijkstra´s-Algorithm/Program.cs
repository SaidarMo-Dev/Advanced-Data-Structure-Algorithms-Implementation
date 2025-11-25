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

	// Display the adjacency matrix
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

	// Dijkstra's Algorithm that finds the shortest paths from a source vertex
	public void Dijkstra(string sourceVertex)
	{

		if (!_vertexDictionary.ContainsKey(sourceVertex))
		{
			Console.WriteLine("Invalid source vertex.");
			return;
		}

		// Initialize distances and visited arrays

		bool[] visited = new bool[_numberOfVertices]; // Trackes processed vertices
		int[] distances = new int[_numberOfVertices];  // Stores shortest distances
		string[] predecessors = new string[_numberOfVertices];  // Tracks the previous vertex on the shortest path

		int sourceIndex = _vertexDictionary[sourceVertex]; // Get start vertex index


		// Initialize distances to infinity and mark all vertices unvisited

		for (int i = 0; i < _numberOfVertices; i++)

		{
			distances[i] = int.MaxValue;
			predecessors[i] = null; // No predecessors initially

			visited[i] = false;

		}



		distances[sourceIndex] = 0; // distance to the source is 0


		// Main loop to process each vertex
		for (int count = 0; count < _numberOfVertices; ++count)
		{
			// Find the unvisited vertex with the smallest distance and mark it as visited
			int minIndex = GetMinDistanceVertex(distances, visited);
			visited[minIndex] = true;

			// Update distances for all neighbors of the current vertex
			for (int v = 0; v < _numberOfVertices; v++)
			{
				if (_adjacencyMatrix[minIndex, v] > 0 && !visited[v] &&
					distances[minIndex] != int.MaxValue
					&&
					distances[minIndex] + _adjacencyMatrix[minIndex, v] < distances[v])
				{

					distances[v] = distances[minIndex] + _adjacencyMatrix[minIndex, v]; ;
					predecessors[v] = GetVertexName(minIndex);


				}
			}

		}

		// Display the shortest paths and their distances
		for (int i = 0; i < _numberOfVertices; i++)
		{
			Console.WriteLine($"\nFrom {sourceVertex} To {GetVertexName(i)} => Distance : {distances[i]} , Path : {GetPath(predecessors, i)}");

		}

	}

	// Helper method to get the shortest path for a vertex
	private string GetPath(string[] predecessors, int currentIndex)
	{
		if (predecessors[currentIndex] == null)
			return GetVertexName(currentIndex);

		return GetPath(predecessors, _vertexDictionary[predecessors[currentIndex]]) + " -> " + GetVertexName(currentIndex);
	}

	// Helper method to get minimum node index
	private int GetMinDistanceVertex(int[] distances, bool[] visited)
	{
		int minNode = int.MaxValue;

		int minNodeIndex = 0;

		for (int i = 0; i < _numberOfVertices; i++)
		{
			if (distances[i] < minNode && !visited[i])
			{
				minNodeIndex = i;
			}
		}

		return minNodeIndex;
	}

	// Helper method to get vertex name by index
	private string GetVertexName(int index)
	{
		foreach (var pair in _vertexDictionary)
		{
			if (pair.Value == index)
				return pair.Key;
		}
		return null;
	}

	// Main method to demonstrate the graph and traversal algorithms
	public static void Main(string[] args)
	{
		// Define vertices
		List<string> vertices = new List<string> { "A", "B", "C", "D", "E" };

		// Create an undirected graph
		Graph graph = new Graph(vertices, enGraphDirectionType.unDirected);

		// Add edges with weights
		graph.AddEdge("A", "B", 4);
		graph.AddEdge("A", "C", 1);
		graph.AddEdge("C", "B", 2);
		graph.AddEdge("C", "D", 4);
		graph.AddEdge("B", "E", 4);
		graph.AddEdge("D", "E", 1);



		// Display the graph
		graph.DisplayGraph("Adjacency Matrix (Undirected Graph):");


		graph.Dijkstra("A");
		Console.ReadKey();
	}
}

public class NodeInfo
{
	public required string Name { get; set; }
	public int Distance { get; set; }
	public string? Prev { get; set; } = null;


}